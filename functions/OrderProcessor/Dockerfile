# Use .NET 10 SDK for building
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY ["OrderProcessor.csproj", "."]
RUN dotnet restore "OrderProcessor.csproj"

# Copy everything else and build
COPY . .
RUN dotnet build "OrderProcessor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderProcessor.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage/image
FROM mcr.microsoft.com/dotnet/azure-functions/dotnet-isolated:4-dotnet-isolated10.0 AS final
WORKDIR /home/site/wwwroot
COPY --from=publish /app/publish .
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true
