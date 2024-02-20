using Api.Services.Predictors;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;
using System;
using System.Net.Http;
using System.Net.Security;
using System.Threading;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.OpenApi.Models;

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

// PreCog Services
builder.Services.AddScoped<PredictorFactory>();

// Grpc
builder.Services.AddGrpcClient<PredictorGrpc.PredictorGrpcClient>(o =>
{
    o.Address = new Uri("dns:///predictor:50051");
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();