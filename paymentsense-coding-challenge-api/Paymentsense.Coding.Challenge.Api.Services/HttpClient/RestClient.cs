using Paymentsense.Coding.Challenge.Api.Services.Logging;
using Serilog;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services.HttpClient
{
    public class RestClient : IRestClient
    {
        private static readonly ILogger Logger = LogManager.GetLogger<RestClient>();

        private readonly System.Net.Http.HttpClient httpClient;

        public RestClient(System.Net.Http.HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<RestResponse> GetAsync(string url)
        {
            return Submit(HttpMethod.Get, url);
        }

        private async Task<RestResponse> Submit(HttpMethod method, string url)
        {
            var request = GetHttpRequestMessage(method, url);

            try
            {
                var httpResponse = await httpClient.SendAsync(request).ConfigureAwait(false);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    var responseBody = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var error = new
                    {
                        StatusCode = (int)httpResponse.StatusCode,
                        ReasonPhrase = httpResponse.ReasonPhrase,
                        Request = request,
                        ResponseBody = responseBody
                    };
                    Logger.Error("@{error}", error.ToString());

                    return new RestResponse { StatusCode = httpResponse.StatusCode, ReasonPhrase = httpResponse.ReasonPhrase };
                }

                var response = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                return new RestResponse { Response = response, StatusCode = httpResponse.StatusCode, IsSuccessStatusCode = true };
            }
            catch (Exception exception)
            {
                var error = new
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    RequestMessage = request
                };
                Logger.Error(exception, "@{error}", error.ToString());

                throw;
            }
            finally
            {
                request.Dispose();
            }
        }

        private HttpRequestMessage GetHttpRequestMessage(HttpMethod method, string url)
        {
            var request = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(url)
            };

            return request;
        }
    }
}
