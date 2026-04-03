using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.OpenRouter.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.OpenRouter.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class OpenRouterOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="OpenRouterOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddOpenRouterOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IOpenRouterOpenApiHttpClient, OpenRouterOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="OpenRouterOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddOpenRouterOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IOpenRouterOpenApiHttpClient, OpenRouterOpenApiHttpClient>();

        return services;
    }
}
