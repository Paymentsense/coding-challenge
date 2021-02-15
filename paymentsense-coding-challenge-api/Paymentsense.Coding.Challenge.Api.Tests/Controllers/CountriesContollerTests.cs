using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Paymentsense.Coding.Challenge.Api.Controllers;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Parameters;
using Paymentsense.Coding.Challenge.Api.Services;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers
{
    public class CountriesControllerTests
    {
        private readonly Fixture _fixture;

        private readonly ICountriesRestService _countriesRestService;

        private readonly CountriesController _controller;

        public CountriesControllerTests()
        {
            _fixture = new Fixture();

            _countriesRestService = Substitute.For<ICountriesRestService>();
            _controller = new CountriesController(_countriesRestService);
        }

        [Fact]
        public async Task Get_Pagination_OnInvoke_ReturnsExpectedMessage()
        {
            var queryParams = new GetCountriesQueryParameters
            {
                Page = 0,
                Take = 10
            };

            var expectedResponse = _fixture.Create<CountryForPaginationResponse>();

            _countriesRestService.GetAllForPagination(queryParams.Page, queryParams.Take).Returns(expectedResponse);

            var response = await _controller.GetAllCountriesForPagination(queryParams);
            
            var result = response.Result as OkObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().Be(expectedResponse);
        }

        [Fact]
        public async Task Get_GetByCode_OnInvoke_ReturnsExpectedMessage()
        {
            var code = "Code";

            var expectedResponse = _fixture.Create<Country>();

            _countriesRestService.GetByCode(code).Returns(expectedResponse);

            var response = await _controller.GetByCode(code);

            var result = response.Result as OkObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().Be(expectedResponse);
        }
    }
}
