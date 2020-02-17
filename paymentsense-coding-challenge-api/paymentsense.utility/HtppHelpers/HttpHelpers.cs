using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace paymentsense.utility.HtppHelpers
{
    public class HttpHelpers : IHttpHelpers
    {
        private readonly HttpClient _client;

        public HttpHelpers(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> Get<T>(string url)
        {
            T data = default(T);
            try
            {
                if (!string.IsNullOrWhiteSpace(url))
                {
                    var httpResponse = await _client.GetAsync(url);
                    if (httpResponse != null && httpResponse.IsSuccessStatusCode)
                    {
                        var content = await httpResponse.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<T>(content);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return data;
        }

        public async Task<T> Post<T>(string url, T data)
        {
            throw new NotImplementedException();
        }
    }
}
