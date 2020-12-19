using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Paymentsense.Coding.Challenge.Api.Controllers;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers
{
    public class CountryControllerTests
    {
        [Fact]
        public void Get_OnInvoke_ReturnsExpectedMessage()
        {
            var controller = new PaymentsenseCodingChallengeController();

            var result = controller.Get().Result as OkObjectResult;

            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().Be("Paymentsense Coding Challenge!");
        }

        //[TestMethod]
        //[ExpectedException(typeof(BadRequestException))]
        //public async Task GivenNullDateThrowException()
        //{
        //    SetUpWithGoodData();
        //    await _service.GetRetailOcfsV5(StringsAsHeader(CorrectHeaderName, string.Empty));
        //}
    }
}
