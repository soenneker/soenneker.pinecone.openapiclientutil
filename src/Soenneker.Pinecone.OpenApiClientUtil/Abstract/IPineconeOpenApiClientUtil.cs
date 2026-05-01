using Soenneker.Pinecone.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Pinecone.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IPineconeOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<PineconeOpenApiClient> Get(CancellationToken cancellationToken = default);
}
