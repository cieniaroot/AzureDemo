# Use .NET 10 SDK for building
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj files and restore
COPY ["WeatherService.Api/WeatherService.Api.csproj", "WeatherService.Api/"]
COPY ["WeatherService.Core/WeatherService.Core.csproj", "WeatherService.Core/"]
COPY ["WeatherService.Infrastructure/WeatherService.Infrastructure.csproj", "WeatherService.Infrastructure/"]
RUN dotnet restore "WeatherService.Api/WeatherService.Api.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/WeatherService.Api"
RUN dotnet build "WeatherService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherService.Api.dll"]
