using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Pinecone.HttpClients.Abstract;
using Soenneker.Pinecone.OpenApiClientUtil.Abstract;
using Soenneker.Pinecone.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Pinecone.OpenApiClientUtil;

/// <inheritdoc cref="IPineconeOpenApiClientUtil" />
public sealed class PineconeOpenApiClientUtil : IPineconeOpenApiClientUtil
{
    private readonly AsyncSingleton<PineconeOpenApiClient> _client;

    public PineconeOpenApiClientUtil(IPineconeOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<PineconeOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient)
            {
                BaseUrl = httpClient.BaseAddress!.ToString().TrimEnd('/')
            };

            return new PineconeOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<PineconeOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
