using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Paymentsense.Coding.Challenge.Api.Clients;
using Paymentsense.Coding.Challenge.Api.Controllers;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Services
{
    public class CountriesServiceTests
    {
        private readonly List<CountryModel> _countriesMock;

        public CountriesServiceTests()
        {
            var country = new CountryModel
            {
                Name = "Test Country",
                Flag = "flag",
                Population = 123456,
                Timezones = new[] {"UTC", "UTC+01:00"},
                Languages = new[] {new Language() {Name = "English"}},
                Currencies = new[] {new CurrencyModel() {Name = "GBP"}},
                Capital = "London",
                Borders = new[] {"IRL"}
            };

            _countriesMock = Enumerable.Range(1, 100).Select(x => country).ToList();
        }

        [Fact]
        public async void GetCountries_OnInvoke_ReturnsCountriesFromApiClientFirstCall_NoPagination()
        {
            var mockCountriesApiClient = new Mock<ICountriesApiClient>();
            mockCountriesApiClient.Setup(c => c.GetCountries()).ReturnsAsync(_countriesMock);

            var mockCache = new Mock<ICountryCache>();
            mockCache.Setup(c => c.GetCountries()).Returns(new List<CountryModel>());
            var countriesService = new CountriesService(mockCache.Object, mockCountriesApiClient.Object);

            var result = await countriesService.GetCountries(null, null);

            result.Should().BeOfType<List<CountryModel>>();
            result.Should().BeSameAs(_countriesMock);
            mockCountriesApiClient.Verify(c => c.GetCountries(), Times.Once);
            mockCache.Verify(c => c.GetCountries(), Times.Once);
        }

        [Fact]
        public async void GetCountries_OnInvoke_PopulatesCacheOnFirstCall_NoPagination()
        {
            var mockCountriesApiClient = new Mock<ICountriesApiClient>();
            mockCountriesApiClient.Setup(c => c.GetCountries()).ReturnsAsync(_countriesMock);

            var mockCache = new Mock<ICountryCache>();
            mockCache.Setup(c => c.GetCountries()).Returns(new List<CountryModel>());
            var countriesService = new CountriesService(mockCache.Object, mockCountriesApiClient.Object);

            var result = await countriesService.GetCountries(null, null);
            mockCache.Verify(c => c.PopulateCountries(result), Times.Once);

            mockCache.Verify(c => c.GetCountries(), Times.Once);
        }

        [Fact]
        public async void GetCountries_OnInvoke_ReturnsCountriesFromCacheSecondCall_NoPagination()
        {
            var mockCountriesApiClient = new Mock<ICountriesApiClient>();

            var mockCache = new Mock<ICountryCache>();
            mockCache.Setup(c => c.GetCountries()).Returns(_countriesMock);
            var countriesService = new CountriesService(mockCache.Object, mockCountriesApiClient.Object);

            var result = await countriesService.GetCountries(null, null);

            result.Should().BeOfType<List<CountryModel>>();
            result.Should().BeSameAs(_countriesMock);
            mockCountriesApiClient.Verify(c => c.GetCountries(), Times.Never);
            mockCache.Verify(c => c.GetCountries(), Times.Once);
        }

        [Fact]
        public async void GetCountries_OnInvoke_Returns10Countries_Pagination()
        {
            var mockCountriesApiClient = new Mock<ICountriesApiClient>();
            mockCountriesApiClient.Setup(c => c.GetCountries()).ReturnsAsync(_countriesMock);

            var mockCache = new Mock<ICountryCache>();
            mockCache.Setup(c => c.GetCountries()).Returns(new List<CountryModel>());
            var countriesService = new CountriesService(mockCache.Object, mockCountriesApiClient.Object);

            var result = await countriesService.GetCountries(10, 0);

            result.Should().HaveCount(10);
        }

        [Fact]
        public async void GetCountries_OnInvoke_ReturnsDifferent10Countries_Pagination()
        {
            var mockCountriesApiClient = new Mock<ICountriesApiClient>();
            mockCountriesApiClient.Setup(c => c.GetCountries()).ReturnsAsync(_countriesMock);

            var mockCache = new Mock<ICountryCache>();
            mockCache.Setup(c => c.GetCountries()).Returns(new List<CountryModel>());
            var countriesService = new CountriesService(mockCache.Object, mockCountriesApiClient.Object);

            var result = await countriesService.GetCountries(10, 0);
            var resultNextPage = await countriesService.GetCountries(10, 1);
            result.Should().HaveCount(10);
            resultNextPage.Should().HaveCount(10);
            resultNextPage.Should().NotBeSameAs(result);
        }
    }
}