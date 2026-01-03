# Azure Learning Demo Application

This project is a boilerplate for a microservices architecture on Azure using .NET 10 and Angular 21.

## Directory Structure

- /services/WeatherService: .NET 10 Web API (Clean Architecture)
- /functions/OrderProcessor: .NET 10 Azure Function (Queue Triggered)
- /web/client-portal: Angular 21 SPA
- /infrastructure: Bicep templates for provisioning

## Prerequisites

- .NET 10 SDK
- Azure Functions Core Tools (for local dev)
- Azure CLI
- Node.js & Angular CLI 21

## Provisioning to Azure

Follow these steps to provision the infrastructure:

### 1. Login to Azure
```bash
az login
```

### 2. Create a Resource Group
```bash
az group create --name AzureDemoRG --location eastus
```

### 3. Deploy Infrastructure via Bicep
```bash
az deployment group create \
  --resource-group AzureDemoRG \
  --template-file infrastructure/main.bicep \
  --parameters prefix=azlearning
```

### 4. Build and Push Docker Image (Weather Service)
```bash
# Assuming Azure Container Registry is created or using Docker Hub
az acr login --name <your-acr-name>
docker build -t <your-acr-name>.azurecr.io/weather-api:latest services/WeatherService
docker push <your-acr-name>.azurecr.io/weather-api:latest
```

### 5. Deploy Azure Function
```bash
cd functions/OrderProcessor
func azure functionapp publish azlearning-order-processor
```

## Architecture Notes

- **Clean Architecture:** The WeatherService is split into Api, Core, and Infrastructure layers.
- **Microservices:** Each service is containerized (see Dockerfile).
- **Serverless:** Background tasks are handled by Azure Functions with isolated worker model.
- **Modern Frontend:** Angular 21 utilizing latest signals and standalone components.

