\# Project Context: Azure Learning Demo

\*\*Stack:\*\* .NET 10 | Angular 21 | Azure Microservices



\## 🎯 Project Goals

\- Learn Azure integration patterns (Identity, Messaging, Scaling).

\- Implement a distributed microservices architecture.

\- Utilize serverless components via Azure Functions.



\## 🏗️ Architecture Overview

\- \*\*Frontend:\*\* Angular 21 SPA hosted on Azure Static Web Apps.

\- \*\*API Gateway:\*\* Azure API Management (APIM) or YARP.

\- \*\*Microservices:\*\* .NET 10 Web APIs running on Azure Container Apps.

\- \*\*Serverless:\*\* .NET 10 Azure Functions for background processing.

\- \*\*Service Bus:\*\* For asynchronous communication between services.

\- \*\*IaC:\*\* Azure Bicep for resource provisioning.



\## 📂 Directory Structure

\- `/apps/client-portal`: Angular 21 application.

\- `/services/catalog-api`: .NET 10 Microservice (Core logic).

\- `/workers/order-processor`: .NET 10 Azure Functions (Queue-triggered).

\- `/infra`: Bicep templates for environment setup.

\- `/docs`: Architecture diagrams and API specs.



\## 🛠️ Development Standards

\- \*\*Pattern:\*\* Clean Architecture (Domain, Application, Infrastructure, Web).

\- \*\*Messaging:\*\* Azure Service Bus for event-driven triggers.

\- \*\*State:\*\* Azure SQL for relational data; Redis for caching.

\- \*\*Security:\*\* Managed Identities for all resource-to-resource communication (No connection strings).



\## 🚀 Deployment Pipeline

1\. Lint and Test.

2\. Build Docker images for Container Apps.

3\. Deploy Infrastructure via Bicep.

4\. Push code to Azure Container Registry / Function Apps.

