using System.Net.Http;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
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
    }
}
