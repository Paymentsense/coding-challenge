using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Paymentsense.Coding.Challenge.Api.Models;

namespace Paymentsense.Coding.Challenge.Api.Clients
{
    internal class CountriesApiClient : ICountriesApiClient
    {
        private readonly IHttpClientFactory _clientFactory;

        public CountriesApiClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<CountryModel>> GetCountries()
        {
            using var client = _clientFactory.CreateClient();
            var responseStream = client.GetStreamAsync(
                "https://restcountries.eu/rest/v2/all?fields=name;flag;population;timezones;currencies;languages;capital;borders");

            return await JsonSerializer.DeserializeAsync<List<CountryModel>>(await responseStream);
        }
    }
}