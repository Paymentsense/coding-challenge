using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using paymentsense.geographic.business;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class GeographicController : ControllerBase
    {
        IGeographic _geographic;
        public GeographicController(IGeographic geographic)
        {
            _geographic = geographic;
        }

        // GET: Geographic/countries
        [HttpGet]
        [Route("countries")]
        public async Task<IActionResult> GetCountries()
        {
            var data = await _geographic.GetCountries();
            return Ok(data);
        }

    }
}
