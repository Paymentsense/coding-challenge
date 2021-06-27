using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<CountryModel>> GetCountries(int? pageNumber, int? page)
        {
            var countries = _countryCache.GetCountries();
            if (countries.Count == 0)
            {
                countries = await _countriesApiClient.GetCountries();
                _countryCache.PopulateCountries(countries);
            }

            if (page == null || pageNumber == null)
            {
                return countries;
            }

            var numToSkip = page.Value * pageNumber.Value;
            return countries.Skip(numToSkip).Take(pageNumber.Value).ToList();
        }
    }
}