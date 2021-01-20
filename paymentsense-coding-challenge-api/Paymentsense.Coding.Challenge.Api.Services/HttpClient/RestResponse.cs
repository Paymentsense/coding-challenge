using System.Net;

namespace Paymentsense.Coding.Challenge.Api.Services.HttpClient
{
    public class RestResponse
    {
        public bool IsSuccessStatusCode { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string Response { get; set; }

        public string ReasonPhrase { get; set; }
    }
}
