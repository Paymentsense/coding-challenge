using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsenseCodingChallengeController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            var client = new HttpClient();
            var res = await client.GetAsync("https://restcountries.eu/rest/v2/all?fields=name");
            var resRaw = await res.Content.ReadAsStringAsync();

            return Ok(resRaw);
        }
    }
}