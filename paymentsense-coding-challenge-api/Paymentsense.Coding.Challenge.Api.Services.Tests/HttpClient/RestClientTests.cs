using FluentAssertions;
using Paymentsense.Coding.Challenge.Api.Services.HttpClient;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Services.Tests.HttpClient
{
    public class RestClientTests
    {
        private const string url = "https://restcountries.eu/rest/v2/all";

        private readonly RestClient sut;

        public RestClientTests()
        {
            sut = new RestClient(new System.Net.Http.HttpClient());
        }

        [Fact]
        [Trait("Category", "Integration")]
        public async Task GetAsync_OnInvoke_ReturnRestResponse()
        {
            // Act
            var result = await sut.GetAsync(url).ConfigureAwait(false);

            // Assert
            result.IsSuccessStatusCode.Should().Be(true);
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
            result.Response.Should().ContainEquivalentOf("\"name\":\"Afghanistan\"");
        }
    }
}
