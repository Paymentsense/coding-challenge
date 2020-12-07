using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paymentsense.Coding.Challenge.Api.Interfaces;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsenseCodingChallengeController : ControllerBase
    {
        public ICountryDataProvider _countryRepositoryService { get; }

        public PaymentsenseCodingChallengeController(ICountryDataProvider countryRepositoryService)
        {
            _countryRepositoryService = countryRepositoryService;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Paymentsense Coding Challenge!");
        }

        [ResponseCache(Duration = int.MaxValue)]
        [Route("countries/list")]
        [HttpGet]
        public async Task<ActionResult> CountryList()
        {
            var list = await _countryRepositoryService.GetCountryList();
            return Ok(list);
        }
    }
}
