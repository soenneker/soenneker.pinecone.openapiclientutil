using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Pinecone.HttpClients.Abstract;
using Soenneker.Pinecone.OpenApiClientUtil.Abstract;
using Soenneker.Pinecone.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Pinecone.OpenApiClientUtil;

///<inheritdoc cref="IPineconeOpenApiClientUtil"/>
public sealed class PineconeOpenApiClientUtil : IPineconeOpenApiClientUtil
{
    private readonly AsyncSingleton<PineconeOpenApiClient> _client;

    public PineconeOpenApiClientUtil(IPineconeOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<PineconeOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Pinecone:ApiKey");
            string authHeaderValueTemplate = configuration["Pinecone:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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