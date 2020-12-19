using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paymentsense.Coding.Challenge.Api.Services;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        public ICountryServices _countryServices { get; }

        public CountryController(Lazy<ICountryServices> _lazyCountryServices)
        {
            _countryServices = _lazyCountryServices.Value;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _countryServices.GetAllAsync();

            return Ok(countries);

        }
    }
}
