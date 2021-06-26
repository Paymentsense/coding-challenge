using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Paymentsense.Coding.Challenge.Api.Controllers;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers
{
    public class CountriesControllerTests
    {
        [Fact]
        public async void Get_OnInvoke_ReturnsCountries()
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

            var countriesMock = new List<CountryModel>() {country};

            var mockCountriesService = new Mock<ICountriesService>();
            mockCountriesService.Setup(c => c.GetCountries()).ReturnsAsync(countriesMock);

            var controller = new CountriesController(mockCountriesService.Object);

            var result = (await controller.Get()).Result as OkObjectResult;

            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeOfType<List<CountryModel>>();
            result.Value.Should().Be(countriesMock);
            mockCountriesService.Verify(c => c.GetCountries(), Times.Once);
        }
    }
}