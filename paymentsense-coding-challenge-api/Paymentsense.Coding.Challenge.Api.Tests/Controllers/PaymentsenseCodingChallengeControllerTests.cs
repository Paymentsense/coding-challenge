using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Protected;
using Paymentsense.Coding.Challenge.Api.Controllers;
using Paymentsense.Coding.Challenge.Api.Interfaces;
using Paymentsense.Coding.Challenge.Api.Services;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers
{
    public class PaymentsenseCodingChallengeControllerTests
    {
        [Fact]
        public void Get_OnInvoke_ReturnsExpectedMessage()
        {
            var countryRepoServiceMock = new Mock<ICountryDataProvider>();
            var controller = new PaymentsenseCodingChallengeController(countryRepoServiceMock.Object);

            var result = controller.Get().Result as OkObjectResult;

            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().Be("Paymentsense Coding Challenge!");
        }

        [Fact]
        public void CountryList_MissingDataSource_ReturnsErrorMessage()
        {
            // Mock configuration to return wrong config key
            var configurationMock = new Mock<IConfiguration>();
            var configurationSection = new Mock<IConfigurationSection>();
            configurationSection.Setup(a => a.Value).Returns("testvalue");
            configurationMock.Setup(a => a.GetSection("TestValueKey")).Returns(configurationSection.Object);

            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var countryRepoService = new CountryDataProvider(httpClientFactoryMock.Object, configurationMock.Object);
            var controller = new PaymentsenseCodingChallengeController(countryRepoService);

            Assert.ThrowsAsync<ApplicationException>(() => controller.CountryList());
        }

        [Fact]
        public async Task CountryList_WrongDataSource_ReturnsNullMessage()
        {
            // Mock configuration to return wrong data source url
            var configurationMock = new Mock<IConfiguration>();
            var configurationSection = new Mock<IConfigurationSection>();
            configurationSection.Setup(a => a.Value).Returns("test123");
            configurationMock.Setup(a => a.GetSection("DataSource")).Returns(configurationSection.Object);

            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var mockHttpMessageHandlerMock = new Mock<HttpMessageHandler>();

            mockHttpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                });

            var client = new HttpClient(mockHttpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://restcountries.eu/rest/v2/all"),
            };
            httpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

            var countryRepoService = new CountryDataProvider(httpClientFactoryMock.Object, configurationMock.Object);
            var controller = new PaymentsenseCodingChallengeController(countryRepoService);

            var result = await controller.CountryList() as ObjectResult;
            Assert.Null(result.Value);
        }
    }
}
