using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Paymentsense.Coding.Challenge.Api.Parameters
{
    public class GetCountriesQueryParameters
    {
        [BindRequired]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value larger or equal to {1}")]
        public int Page { get; set; }

        [BindRequired]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value larger or equal to {1}")]
        public int Take { get; set; }
    }
}
