using Autofac.Extras.Moq;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Paymentsense.Coding.Challenge.Api.Controllers;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services.Countries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers
{
    public class CountriesControllerTests
    {
        private readonly Fixture fixture;

        private readonly Mock<ICountryService> countryServiceMock;

        private readonly CountriesController sut;

        public CountriesControllerTests()
        {
            fixture = new Fixture();
            var mocker = AutoMock.GetLoose();
            countryServiceMock = mocker.Mock<ICountryService>();
            sut = mocker.Create<CountriesController>();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        public async Task GetCountries_OnInvoke_ReturnsCountries(int countriesCount)
        {
            // Arrange
            var countries = fixture.CreateMany<CountryBasic>(countriesCount).ToList();
            countryServiceMock.Setup(x => x.GetCountriesBasicAsync()).ReturnsAsync(countries);

            // Act
            var result = (await sut.GetCountries().ConfigureAwait(false)).Result as OkObjectResult;

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.As<List<CountryBasic>>().Count.Should().Be(countriesCount);
            countryServiceMock.Verify(x => x.GetCountriesBasicAsync(), Times.Once);
        }

        [Fact]
        public async Task GetCountry_OnInvoke_ReturnsCountry()
        {
            // Arrange
            var countryName = "";
            var country = fixture.Create<Country>();
            countryServiceMock.Setup(x => x.GetCountryAsync(It.IsAny<string>())).ReturnsAsync(country);

            // Act
            var result = (await sut.GetCountry(countryName).ConfigureAwait(false)).Result as OkObjectResult;

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.As<Country>().Should().BeEquivalentTo(country);
            countryServiceMock.Verify(x => x.GetCountryAsync(It.IsAny<string>()), Times.Once);
        }
    }
}
