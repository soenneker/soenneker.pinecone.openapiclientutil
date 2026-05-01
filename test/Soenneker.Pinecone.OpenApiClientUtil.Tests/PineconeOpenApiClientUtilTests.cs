using Soenneker.Pinecone.OpenApiClientUtil.Abstract;
using Soenneker.TestHosts.Unit;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Pinecone.OpenApiClientUtil.Tests;

[ClassDataSource<UnitTestHost>(Shared = SharedType.PerTestSession)]
public sealed class PineconeOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IPineconeOpenApiClientUtil _openapiclientutil;

    public PineconeOpenApiClientUtilTests(UnitTestHost host) : base(host)
    {
        _openapiclientutil = Resolve<IPineconeOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
