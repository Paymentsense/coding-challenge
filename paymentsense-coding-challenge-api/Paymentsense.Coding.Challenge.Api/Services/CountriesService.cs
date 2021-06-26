using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Paymentsense.Coding.Challenge.Api.Clients;
using Paymentsense.Coding.Challenge.Api.Models;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly ICountriesApiClient _countriesApiClient;
        private readonly ICountryCache _countryCache;

        public CountriesService(ICountryCache cache, ICountriesApiClient countriesApiClient)
        {
            _countriesApiClient = countriesApiClient;
            _countryCache = cache;
        }

        public async Task<List<CountryModel>> GetCountries()
        {
            var countries = _countryCache.GetCountries();
            if (countries.Count != 0)
            {
                return countries;
            }

            countries = await _countriesApiClient.GetCountries();
            _countryCache.PopulateCountries(countries);

            return countries;
        }
    }
}