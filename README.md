[![](https://img.shields.io/nuget/v/soenneker.pinecone.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.pinecone.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.pinecone.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.pinecone.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.pinecone.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.pinecone.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.pinecone.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.pinecone.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Pinecone.OpenApiClientUtil

Provides a configured Pinecone Nexus client and reuses it for the lifetime of the registered service.

## Installation

```bash
dotnet add package Soenneker.Pinecone.OpenApiClientUtil
```

## Configuration

```json
{
  "Pinecone": {
    "ApiKey": "your-api-key",
    "ClientBaseUrl": "https://your-nexus-host/api/"
  }
}
```

## Usage

```csharp
using Soenneker.Pinecone.OpenApiClientUtil.Abstract;
using Soenneker.Pinecone.OpenApiClientUtil.Registrars;

services.AddPineconeOpenApiClientUtilAsSingleton();

IPineconeOpenApiClientUtil pinecone = serviceProvider
    .GetRequiredService<IPineconeOpenApiClientUtil>();

var client = await pinecone.Get(cancellationToken);
var project = await client.Nexus.Project.GetAsync(
    cancellationToken: cancellationToken);
```

Use `AddPineconeOpenApiClientUtilAsScoped()` when each application scope should have its own generated client wrapper. The authenticated HTTP provider remains shared and is disposed by the service container at shutdown.
