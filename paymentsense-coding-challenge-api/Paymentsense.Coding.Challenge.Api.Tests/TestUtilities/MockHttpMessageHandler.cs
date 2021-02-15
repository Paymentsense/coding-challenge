using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Tests.TestUtilities
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        public string ResponseContent { get; set; }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(ResponseContent)
            };
        }
    }
}
