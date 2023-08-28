FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api/Api.csproj", "Api/"]
RUN dotnet restore "Api/Api.csproj"
COPY . .
WORKDIR "/src/Api"
RUN dotnet build "Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 4000
EXPOSE 4001

ENV ASPNETCORE_HTTPS_PORT=https://+:4000
ENV ASPNETCORE_HTTP_PORT=http://+:4001
ENV ASPNETCORE_URLS=http://+:4001

ENTRYPOINT ["dotnet", "Api.dll"]
