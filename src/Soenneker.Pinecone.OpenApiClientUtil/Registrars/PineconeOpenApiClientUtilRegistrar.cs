using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Pinecone.HttpClients.Registrars;
using Soenneker.Pinecone.OpenApiClientUtil.Abstract;

namespace Soenneker.Pinecone.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class PineconeOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="PineconeOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddPineconeOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddPineconeOpenApiHttpClientAsSingleton()
                .TryAddSingleton<IPineconeOpenApiClientUtil, PineconeOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="PineconeOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddPineconeOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddPineconeOpenApiHttpClientAsSingleton()
                .TryAddScoped<IPineconeOpenApiClientUtil, PineconeOpenApiClientUtil>();

        return services;
    }
}
