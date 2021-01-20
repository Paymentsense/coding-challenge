using Autofac.Extras.Moq;
using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services.Caching;
using Paymentsense.Coding.Challenge.Api.Services.Countries;
using Paymentsense.Coding.Challenge.Api.Services.HttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Services.Tests.Countries
{
    public class CachedCountryServiceTests
    {
        private readonly Mock<IRestClient> restClientMock;

        private readonly Mock<ICacheService> cacheServiceMock;

        private readonly Fixture fixture;

        private readonly CachedCountryService sut;

        public CachedCountryServiceTests()
        {
            fixture = new Fixture();

            var settings = Options.Create(new AppSettings()
            {
                CacheTimeInSeconds = 300,
                RestCountriesUrl = "localhost"
            });

            var mocker = AutoMock.GetLoose();
            restClientMock = mocker.Mock<IRestClient>();
            cacheServiceMock = mocker.Mock<ICacheService>();

            sut = new CachedCountryService(restClientMock.Object, settings, cacheServiceMock.Object);
        }

        [Fact]
        public async Task GetCountriesAsync_OnInvoke_ReturnsResultFromCacheService()
        {
            // Arrange
            var countries = fixture.CreateMany<Country>(2).ToList();
            cacheServiceMock.Setup(x => x.GetAsync(It.IsAny<object>(), It.IsAny<Func<Task<List<Country>>>>(), It.IsAny<int>()))
                .ReturnsAsync(countries);

            // Act
            var result = await sut.GetCountriesAsync().ConfigureAwait(false);

            // Assert
            result.Should().BeEquivalentTo(countries);
            cacheServiceMock.Verify(x => x.GetAsync(It.IsAny<object>(), It.IsAny<Func<Task<List<Country>>>>(), It.IsAny<int>()),
                Times.Once);
            restClientMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task GetCountriesAsync_OnInvoke_CallFuncGetResultFromAPI()
        {
            // Arrange
            List<Country> countries = null;

            var countriesFromApi = fixture.CreateMany<Country>(2).ToList();
            var countriesJson = JsonConvert.SerializeObject(countriesFromApi);
            restClientMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(new RestResponse()
            {
                Response = countriesJson,
                StatusCode = HttpStatusCode.OK,
                IsSuccessStatusCode = true
            }); ;

            cacheServiceMock.Setup(x => x.GetAsync(It.IsAny<object>(), It.IsAny<Func<Task<List<Country>>>>(), It.IsAny<int>()))
                .Callback<object, Func<Task<List<Country>>>, int>(async (obj, func, val) =>
                {
                    countries = await func();
                }).ReturnsAsync(countries);

            // Act
            var result = await sut.GetCountriesAsync().ConfigureAwait(false);

            // Assert
            countries.Should().BeEquivalentTo(countriesFromApi);
            cacheServiceMock.Verify(x => x.GetAsync(It.IsAny<object>(), It.IsAny<Func<Task<List<Country>>>>(), It.IsAny<int>()),
                Times.Once);
            restClientMock.Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
        }
    }
}
