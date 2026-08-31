using Soenneker.Pinecone.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Pinecone.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached client for the Pinecone Nexus API.
/// </summary>
public interface IPineconeOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the generated client.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The cached Pinecone client.</returns>
    ValueTask<PineconeOpenApiClient> Get(CancellationToken cancellationToken = default);
}
