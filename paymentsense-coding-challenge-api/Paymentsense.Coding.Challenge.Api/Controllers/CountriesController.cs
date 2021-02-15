using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Parameters;
using Paymentsense.Coding.Challenge.Api.Services;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{

    [ApiController]
    [Route("countries")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesRestService _countriesService;

        public CountriesController(ICountriesRestService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet("pagination")]
        [ResponseCache(Duration = 60, VaryByQueryKeys = new string[] { "page", "take" } )]
        public async Task<ActionResult<CountryForPaginationResponse>> GetAllCountriesForPagination([FromQuery()] GetCountriesQueryParameters queryParams )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _countriesService.GetAllForPagination(queryParams.Page, queryParams.Take);

            return Ok(result);
        }

        [HttpGet("{code}")]
        [ResponseCache(Duration = 60, VaryByQueryKeys = new string[] { "code" })]
        public async Task<ActionResult<Country>> GetByCode(string code)
        {
            var result = await _countriesService.GetByCode(code);

            return Ok(result);
        }
    }
}
