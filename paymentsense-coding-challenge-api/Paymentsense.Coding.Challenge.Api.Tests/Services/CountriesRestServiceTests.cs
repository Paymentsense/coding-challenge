using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using MemoryCache.Testing.NSubstitute;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services;
using Paymentsense.Coding.Challenge.Api.Tests.TestUtilities;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Services
{
    public class CountriesRestServiceTests
    {
        private readonly Fixture _fixture;

        private readonly MockHttpMessageHandler _mockHttpMessageHandler;
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;

        private readonly CountriesRestService _sut;

        public CountriesRestServiceTests()
        {
            _fixture = new Fixture();

            _mockHttpMessageHandler = new MockHttpMessageHandler();
            _httpClient = new HttpClient(_mockHttpMessageHandler);

            _memoryCache = Create.MockedMemoryCache();

            _sut = new CountriesRestService(_httpClient, _memoryCache);
        }

        [Fact]
        public async Task GetAllForPagination_OnInvoke_Returns_ResponseObject()
        {
            int page = 1;
            int take = 10;

            var returnedCountries = _fixture.CreateMany<CountryForPagination>(2);

            _mockHttpMessageHandler.ResponseContent = JsonConvert.SerializeObject(returnedCountries);

            var expectedResponse = new CountryForPaginationResponse
            {
                Countries = returnedCountries,
                Meta = new PaginationMeta
                {
                    Page = 1,
                    Take = 10,
                    MaxPage = 1,
                    TotalItems = 2
                }
            };

            var result = await _sut.GetAllForPagination(page, take);

            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task GetAllForPagination_OnInvoke_Returns_ResponseObject_FromMemory()
        {
            int page = 1;
            int take = 10;

            var returnedCountries = _fixture.CreateMany<CountryForPagination>(2);

            _memoryCache.Set("COUNTRIES_CACHE_KEY", returnedCountries);

            var expectedResponse = new CountryForPaginationResponse
            {
                Countries = returnedCountries,
                Meta = new PaginationMeta
                {
                    Page = 1,
                    Take = 10,
                    MaxPage = 1,
                    TotalItems = 2
                }
            };

            var result = await _sut.GetAllForPagination(page, take);

            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task GetAllForPagination_OnInvoke_Returns_ResponseObject_WithCorrectPageTake()
        {
            int page = 2;
            int take = 10;

            var returnedCountries = _fixture.CreateMany<CountryForPagination>(25);

            _mockHttpMessageHandler.ResponseContent = JsonConvert.SerializeObject(returnedCountries);

            var expectedResponse = new CountryForPaginationResponse
            {
                Countries = returnedCountries.Skip((page-1) * take).Take(take),
                Meta = new PaginationMeta
                {
                    Page = 2,
                    Take = 10,
                    MaxPage = 3,
                    TotalItems = 25
                }
            };

            var result = await _sut.GetAllForPagination(page, take);

            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task GetByCode_OnInvoke_Returns_ResponseObject()
        {
            string code = "AAA";

            var expectedResponse = _fixture.Create<Country>();

            _mockHttpMessageHandler.ResponseContent = JsonConvert.SerializeObject(expectedResponse);

            var result = await _sut.GetByCode(code);

            result.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
