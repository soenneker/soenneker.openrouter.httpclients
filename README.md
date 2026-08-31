[![](https://img.shields.io/nuget/v/soenneker.openrouter.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openrouter.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.openrouter.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.openrouter.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.openrouter.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.openrouter.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.openrouter.httpclients/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.openrouter.httpclients/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.OpenRouter.HttpClients

Provides a cached `HttpClient` configured for OpenRouter's API, including bearer authentication.

## Installation

```bash
dotnet add package Soenneker.OpenRouter.HttpClients
```

## Configuration

```json
{
  "OpenRouter": {
    "ApiKey": "your-api-key"
  }
}
```

`OpenRouter:ClientBaseUrl`, `OpenRouter:AuthHeaderName`, and `OpenRouter:AuthHeaderValueTemplate` can override the defaults.

## Usage

```csharp
using Soenneker.OpenRouter.HttpClients.Abstract;
using Soenneker.OpenRouter.HttpClients.Registrars;

services.AddOpenRouterOpenApiHttpClientAsSingleton();

IOpenRouterOpenApiHttpClient provider = serviceProvider
    .GetRequiredService<IOpenRouterOpenApiHttpClient>();

HttpClient client = await provider.Get(cancellationToken);
HttpResponseMessage response = await client.GetAsync("models", cancellationToken);
response.EnsureSuccessStatusCode();
```

The provider owns its cached client. Disposing the provider removes and disposes that client. Scoped registration gives each provider instance its own cached client.
