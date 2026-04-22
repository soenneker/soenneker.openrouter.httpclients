using Soenneker.OpenRouter.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.OpenRouter.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class OpenRouterOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IOpenRouterOpenApiHttpClient _httpclient;

    public OpenRouterOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IOpenRouterOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
