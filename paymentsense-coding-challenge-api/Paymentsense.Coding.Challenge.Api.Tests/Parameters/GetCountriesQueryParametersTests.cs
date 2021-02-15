using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using Paymentsense.Coding.Challenge.Api.Parameters;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Parameters
{
    public class GetCountriesQueryParametersTests
    {
        private readonly List<Tuple<GetCountriesQueryParameters, string>> InvalidTestCases = new List<Tuple<GetCountriesQueryParameters, string>>
        {
            new Tuple<GetCountriesQueryParameters, string>
            (
                new GetCountriesQueryParameters
                {
                    Page = 0,
                    Take = 1
                },
                "Please enter a value larger or equal to 1"
            ),
            new Tuple<GetCountriesQueryParameters, string>
            (
                new GetCountriesQueryParameters
                {
                    Page = 1,
                    Take = 0
                },
                "Please enter a value larger or equal to 1"
            )
        };

        [Fact]
        public void GetCountriesQueryParameters_Should_Be_Valid()
        {
            var model = new GetCountriesQueryParameters
            {
                Page = 1,
                Take = 1
            };

            var results = ValidateModel(model);

            results.Count.Should().Be(0);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void GetCountriesQueryParameters_Should_Be_InValid(int index)
        {
            var testCase = InvalidTestCases[index];

            var model = testCase.Item1;

            var results = ValidateModel(model);

            results[0].ErrorMessage.Should().Be(testCase.Item2);
        }

        private List<ValidationResult> ValidateModel<T>(T model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
