using Api.Services.Predictors;
using Api.Storage;
using Api.Storage.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using System.Threading;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.OpenApi.Models;

namespace Api;

internal abstract class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "preCog API",
                Version = "v1"
            });

            config.EnableAnnotations();
        });
        
        builder.Configuration.AddEnvironmentVariables();
        // Grpc
        builder.Services.AddGrpcClient<PredictorGrpc.PredictorGrpcClient>(o =>
        {
            var predictorPort = Environment.GetEnvironmentVariable("PREDICTOR_PORT");
            var predictorHost = Environment.GetEnvironmentVariable("PREDICTOR_HOST_URI");
            o.Address = new Uri(predictorPort + ":" + predictorHost);
            o.ChannelOptionsActions.Add((Action<GrpcChannelOptions>) (opt =>
            {
                opt.HttpHandler = (HttpMessageHandler) new SocketsHttpHandler()
                {
                    EnableMultipleHttp2Connections = true,
                    PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
                    KeepAlivePingDelay = TimeSpan.FromSeconds(60.0),
                    KeepAlivePingTimeout = TimeSpan.FromSeconds(60.0)
                };
                opt.Credentials = ChannelCredentials.Insecure; 
            }));
        });

        // PreCog Services
        builder.Services.AddScoped<PredictorFactory>();

        // DB
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork<MySqlContext>>();
        builder.Services.AddPooledDbContextFactory<MySqlContext>((sp, options) =>
        {
            var host = Environment.GetEnvironmentVariable("MariaDb_Configuration__Host");
            var port = Environment.GetEnvironmentVariable("MariaDb_Configuration__Port");
            var database = Environment.GetEnvironmentVariable("MariaDb_Configuration__Database");
            var username = Environment.GetEnvironmentVariable("MariaDb_Configuration__Username");
            var password = Environment.GetEnvironmentVariable("MariaDb_Configuration__Password");
            
            string connectionString = $"Server={host};Port={port};Database={database};Uid={username};Pwd={password};";

            options.UseLazyLoadingProxies().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        var app = builder.Build();
        
        // UOW Migration
        using (var scope = app.Services.CreateScope())
        {
            IUnitOfWork uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            uow.Migrate();
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}