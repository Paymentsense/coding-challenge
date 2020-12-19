using Microsoft.AspNetCore.Mvc;
using Moq;
using Paymentsense.Coding.Challenge.Api.Controllers;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers
{
    public class CountryControllerTests
    {
        [Fact]
        public async Task Get_OnInvoke_ReturnsExpectedResult()
        {
            // Arrange
            var controller = sutController();

            // Act
            var result = await controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Get_OnInvoke_ReturnsException()
        {
            // Arrange
            var countryServicMock = new Mock<ICountryServices>();
            countryServicMock
                .Setup(repository => repository.GetAllAsync())
                .ThrowsAsync(new Exception("Error message here"));

            var lazyProductPackageRepository = new Lazy<ICountryServices>(() => countryServicMock.Object);
            var controller = new CountryController(lazyProductPackageRepository);

            // Assert
            var ex = await Assert.ThrowsAsync<Exception>(() => controller.GetAll());
        }

        [Fact]
        public async Task Get_OnInvoke_Returns_200StatusCode()
        {
            //  Arrange
            var controller = sutController();

            //Act
            var result = await controller.GetAll();
            var okResult = result as OkObjectResult;

            //Assert
            Assert.Equal(200, okResult.StatusCode);

        }

        [Fact]
        public async Task Get_OnInvoke_Returns_2Items()
        {
            //  Arrange
            var controller = sutController();

            //Act
            var result = await controller.GetAll();
            var okResult = result as OkObjectResult;
            List<Country> countries = okResult.Value as List<Country>;


            //Assert
            Assert.Equal(2, countries.Count);

        }


        private CountryController sutController()
        {
            var countryServicMock = new Mock<ICountryServices>();
            countryServicMock
                .Setup(repository => repository.GetAllAsync())
                .ReturnsAsync(GetSomeCountriesData);

            var lazyProductPackageRepository = new Lazy<ICountryServices>(() => countryServicMock.Object);
            return new CountryController(lazyProductPackageRepository);
        }

        private List<Country> GetSomeCountriesData()
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
