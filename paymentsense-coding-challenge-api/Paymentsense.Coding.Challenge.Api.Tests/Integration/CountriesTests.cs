using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Integration
{
    public class CountriesTests
    {
        private readonly HttpClient _client;

        public CountriesTests()
        {
            var builder = new WebHostBuilder().UseStartup<Startup>();
            var testServer = new TestServer(builder);
            _client = testServer.CreateClient();
        }

        [Fact]
        public async Task Countries_Pagination_OnInvoke_ReturnsValidResponse()
        {
            var response = await _client.GetAsync("countries/pagination?page=1&take=10");
            var responseString = await response.Content.ReadAsStringAsync();

            response.StatusCode.Should().Be(StatusCodes.Status200OK);
            responseString.Should().NotBeNull();
        }

        [Fact]
        public async Task Countries_Pagination_OnInvoke_ReturnsBadRequest()
        {
            var response = await _client.GetAsync("countries/pagination?page=1;take=0");

            response.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }
    }
}
