#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["test.csproj", "test/"]
RUN dotnet restore "test/test.csproj"
WORKDIR "/src/test"
COPY . .
RUN dotnet build "test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 4000
EXPOSE 4001

ENV ASPNETCORE_HTTPS_PORT=https://+:4000
ENV ASPNETCORE_HTTP_PORT=http://+:4001
ENV ASPNETCORE_URLS=http://+:4001
ENV ASPNETCORE_ENVIRONMENT="Development"

ENTRYPOINT ["dotnet", "test.dll"]