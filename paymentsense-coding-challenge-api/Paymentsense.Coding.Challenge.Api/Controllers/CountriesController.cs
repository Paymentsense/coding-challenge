using Microsoft.AspNetCore.Mvc;
using Paymentsense.Coding.Challenge.Api.Services.Countries;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService countryService;

        public CountriesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetCountries()
        {
            var result = await countryService.GetCountriesBasicAsync();
            return Ok(result);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<string>> GetCountry(string name)
        {
            var result = await countryService.GetCountryAsync(name);
            return Ok(result);
        }
    }
}
