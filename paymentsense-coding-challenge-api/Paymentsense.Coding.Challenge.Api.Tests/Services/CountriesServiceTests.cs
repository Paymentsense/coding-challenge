using System.Collections.Generic;
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

            _countriesMock = new List<CountryModel>() {country};
        }

        [Fact]
        public async void GetCountries_OnInvoke_ReturnsCountriesFromApiClientFirstCall()
        {
            var mockCountriesApiClient = new Mock<ICountriesApiClient>();
            mockCountriesApiClient.Setup(c => c.GetCountries()).ReturnsAsync(_countriesMock);

            var mockCache = new Mock<ICountryCache>();
            mockCache.Setup(c => c.GetCountries()).Returns(new List<CountryModel>());
            var countriesService = new CountriesService(mockCache.Object, mockCountriesApiClient.Object);

            var result = await countriesService.GetCountries();

            result.Should().BeOfType<List<CountryModel>>();
            result.Should().BeSameAs(_countriesMock);
            mockCountriesApiClient.Verify(c => c.GetCountries(), Times.Once);
            mockCache.Verify(c => c.GetCountries(), Times.Once);
        }

        [Fact]
        public async void GetCountries_OnInvoke_PopulatesCacheOnFirstCall()
        {
            var mockCountriesApiClient = new Mock<ICountriesApiClient>();
            mockCountriesApiClient.Setup(c => c.GetCountries()).ReturnsAsync(_countriesMock);

            var mockCache = new Mock<ICountryCache>();
            mockCache.Setup(c => c.GetCountries()).Returns(new List<CountryModel>());
            var countriesService = new CountriesService(mockCache.Object, mockCountriesApiClient.Object);

            var result = await countriesService.GetCountries();
            mockCache.Verify(c => c.PopulateCountries(result), Times.Once);

            mockCache.Verify(c => c.GetCountries(), Times.Once);
        }

        [Fact]
        public async void GetCountries_OnInvoke_ReturnsCountriesFromCacheSecondCall()
        {
            var mockCountriesApiClient = new Mock<ICountriesApiClient>();

            var mockCache = new Mock<ICountryCache>();
            mockCache.Setup(c => c.GetCountries()).Returns(_countriesMock);
            var countriesService = new CountriesService(mockCache.Object, mockCountriesApiClient.Object);

            var result = await countriesService.GetCountries();

            result.Should().BeOfType<List<CountryModel>>();
            result.Should().BeSameAs(_countriesMock);
            mockCountriesApiClient.Verify(c => c.GetCountries(), Times.Never);
            mockCache.Verify(c => c.GetCountries(), Times.Once);
        }
    }
}