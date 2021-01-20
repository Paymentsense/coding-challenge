using Autofac.Extras.Moq;
using AutoFixture;
using FluentAssertions;
using Moq;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Services.Tests.Countries
{
    public class CountryServiceTests
    {
        private readonly Mock<ICachedCountryService> cachedCountryServiceMock;

        private readonly Fixture fixture;

        private readonly CountryService sut;

        public CountryServiceTests()
        {
            fixture = new Fixture();

            var mocker = AutoMock.GetLoose();
            cachedCountryServiceMock = mocker.Mock<ICachedCountryService>();
            sut = mocker.Create<CountryService>();
        }

        [Fact]
        public async Task GetCountriesBasicAsync_OnInvoke_ReturnsCountryBasicDetail()
        {
            // Arrange
            var countries = fixture.CreateMany<Country>(2).ToList();
            cachedCountryServiceMock.Setup(x => x.GetCountriesAsync())
                .ReturnsAsync(countries);

            // Act
            var result = await sut.GetCountriesBasicAsync().ConfigureAwait(false);

            // Assert
            result.Count.Should().Be(countries.Count);
            result.ElementAt(0).Should().Match<CountryBasic>(
                x => x.Name == countries.ElementAt(0).Name && x.Flag == countries.ElementAt(0).Flag);
            result.ElementAt(1).Should().Match<CountryBasic>(
                x => x.Name == countries.ElementAt(1).Name && x.Flag == countries.ElementAt(1).Flag);
            cachedCountryServiceMock.Verify(x => x.GetCountriesAsync(), Times.Once);
        }

        [Fact]
        public async Task GetCountryAsync_OnInvoke_ReturnsCountryDetail()
        {
            // Arrange
            var countries = fixture.CreateMany<Country>(2).ToList();
            var countryName = countries.ElementAt(0).Name;
            cachedCountryServiceMock.Setup(x => x.GetCountriesAsync())
                .ReturnsAsync(countries);

            // Act
            var result = await sut.GetCountryAsync(countryName).ConfigureAwait(false);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(countries.ElementAt(0));
            cachedCountryServiceMock.Verify(x => x.GetCountriesAsync(), Times.Once);
        }
    }
}
