using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Dtos.HttpClientOptions;
using Soenneker.Extensions.Configuration;
using Soenneker.OpenRouter.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.OpenRouter.HttpClients;

///<inheritdoc cref="IOpenRouterOpenApiHttpClient"/>
public sealed class OpenRouterOpenApiHttpClient : IOpenRouterOpenApiHttpClient
{
    private readonly IHttpClientCache _httpClientCache;
    private readonly IConfiguration _config;

    private const string _prodBaseUrl = "https://openrouter.ai/api/v1";

    public OpenRouterOpenApiHttpClient(IHttpClientCache httpClientCache, IConfiguration config)
    {
        _httpClientCache = httpClientCache;
        _config = config;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(nameof(OpenRouterOpenApiHttpClient), (config: _config, baseUrl: _config["OpenRouter:ClientBaseUrl"] ?? _prodBaseUrl), static state =>
        {
            var apiKey = state.config.GetValueStrict<string>("OpenRouter:ApiKey");
            string authHeaderName = state.config["OpenRouter:AuthHeaderName"] ?? "Bearer {token}";
            string authHeaderValueTemplate = state.config["OpenRouter:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            return new HttpClientOptions
            {
                BaseAddress = new Uri(state.baseUrl),
                DefaultRequestHeaders = new Dictionary<string, string>
                {
                    {authHeaderName, authHeaderValue},
                }
            };
        }, cancellationToken);
    }

    public void Dispose()
    {
        _httpClientCache.RemoveSync(nameof(OpenRouterOpenApiHttpClient));
    }

    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(nameof(OpenRouterOpenApiHttpClient));
    }
}
