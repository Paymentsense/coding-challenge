using Microsoft.AspNetCore.Mvc;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{
    // There doesn't seem to be a nice way to expose the Health Check endpoint in the swagger document
    // A better way would be to write a Document Filter for the swagger setup to add it in
    // Doing it this way for brevity sakes, have removed the default HealthCheck setup in Startup.cs
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet("")]
        public ActionResult<string> Get()
        {
            return Ok("Healthy");
        }
    }
}
