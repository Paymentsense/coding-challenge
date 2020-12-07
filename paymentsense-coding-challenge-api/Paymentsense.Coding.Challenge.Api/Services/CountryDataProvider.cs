using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Paymentsense.Coding.Challenge.Api.Interfaces;
using Paymentsense.Coding.Challenge.Api.Models;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public class CountryDataProvider : ICountryDataProvider
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _configuration;

        public CountryDataProvider(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            _configuration = configuration;
        }

        public async Task<Country[]> GetCountryList()
        {
            // Get country data source url from config
            var sourceUrl = _configuration.GetValue<string>("DataSource");
            if (string.IsNullOrEmpty(sourceUrl))
            {
                throw new ApplicationException("Country data source url missing in configuration file");
            }

            // Make call to fetch country list
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync(sourceUrl);
            if (response != null && response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Country[]>(content);
            }

            return null;
        }
    }
}
