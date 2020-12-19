using Microsoft.AspNetCore.Mvc;
using Moq;
using Paymentsense.Coding.Challenge.Api.Controllers;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
namespace Paymentsense.Coding.Challenge.Api.Tests.Services
{
    public class CountryServicesTests
    {
        [Fact]
        public async Task Call_AllCountries_ReturnsExpectedResult()
        {
            // Arrange
            var countryServiceMock = sutService();

            // Act
            var result = await countryServiceMock.GetAllAsync();

            // Assert
            Assert.IsType<List<Country>>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Call_AllCountries_ReturnsException()
        {
            // Arrange
            var countryServicMock = new Mock<ICountryServices>();
            countryServicMock
                .Setup(repository => repository.GetAllAsync())
                .ThrowsAsync(new Exception("Error message here"));

            // Assert
            var ex = await Assert.ThrowsAsync<Exception>(() => countryServicMock.Object.GetAllAsync());
        }

        [Fact]
        public async Task Call_AllCountries_Returns_2Items()
        {
            //  Arrange
            var countryServiceMock = sutService();

            //Act
            var result = await countryServiceMock.GetAllAsync();

            //Assert
            Assert.Equal(2, result.Count);

        }


        private ICountryServices sutService()
        {
            var countryServicMock = new Mock<ICountryServices>();
            countryServicMock
                .Setup(repository => repository.GetAllAsync())
                .ReturnsAsync(GetSomeCountriesData);

            return   countryServicMock.Object;
        }

        private static List<Country> GetSomeCountriesData()
        {
            var countries = new List<Country>();
            countries.Add(new Country()
            {
                Name = "UK",
            });
            countries.Add(new Country()
            {
                Name = "SCOT",
            });
            return countries;
        }

    }
}
