using Soenneker.OpenRouter.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.OpenRouter.HttpClients.Tests;

[Collection("Collection")]
public sealed class OpenRouterOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IOpenRouterOpenApiHttpClient _httpclient;

    public OpenRouterOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IOpenRouterOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
