using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Paymentsense.Coding.Challenge.Api.Models;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {
        private static List<CountryModel> Countries { get; set; } = new List<CountryModel>();

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            if (Countries.Count == 0)
            {
                await PopulateCountries();
            }

            return Ok(Countries);
        }


        private static async Task PopulateCountries()
        {
            using var client = new HttpClient();
            var responseStream = client.GetStreamAsync(
                "https://restcountries.eu/rest/v2/all?fields=name;flag;population;timezones;currencies;language;capital;borders");

            Countries = await JsonSerializer.DeserializeAsync<List<CountryModel>>(await responseStream);
        }
    }
}