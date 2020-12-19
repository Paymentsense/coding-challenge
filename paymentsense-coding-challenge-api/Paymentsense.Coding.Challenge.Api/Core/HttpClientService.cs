namespace Paymentsense.Coding.Challenge.Api.Core
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
   
    public class HttpClientService : IHttpClientService
    {
        public async Task<HttpResponseMessage> GetAsync(string url, string token)
        {
            var httpRequest = GetHttpRequestMessageWithBearerToken(new Uri(url), HttpMethod.Get, token);

            var httpClient = CreateHttpClient();

            return await httpClient.SendAsync(httpRequest);
        }

        private static HttpClient CreateHttpClient()
        {
            return new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(300)
            };
        }

        private static HttpRequestMessage GetHttpRequestMessageWithBearerToken(Uri uri, HttpMethod method, string bearerToken)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = uri,
                Method = method
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            return request;
        }
    }
}
