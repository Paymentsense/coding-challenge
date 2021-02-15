using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Paymentsense.Coding.Challenge.Api.Models;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public class CountriesRestService : ICountriesRestService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;

        public const string CountriesCacheKey = "COUNTRIES_CACHE_KEY";

        private const string BaseUrl = "https://restcountries.eu/rest/v2/";

        private const string GetAllForPaginationResource = "all?fields=name;alpha3Code;flag;";

        private const string CodeSegment = "{code}";
        private readonly string GetByCodeResource = $"alpha/{CodeSegment}";

        public CountriesRestService(HttpClient httpClient, IMemoryCache memoryCache)
        {
            _httpClient = httpClient;
            _memoryCache = memoryCache;

            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<CountryForPaginationResponse> GetAllForPagination(int page, int take)
        {
            IEnumerable<CountryForPagination> countries = await GetCountries();

            var numberOfCountries = countries.Count();

            return new CountryForPaginationResponse
            {
                Countries = countries
                    .Skip((page - 1) * take)
                    .Take(take),
                Meta = new PaginationMeta
                {
                    Page = page,
                    Take = take,
                    MaxPage = Convert.ToInt32(Math.Ceiling(numberOfCountries / (decimal)take)),
                    TotalItems = numberOfCountries
                }
            };
        }

        public async Task<Country> GetByCode(string code)
        {
            var response = await _httpClient.GetAsync(GetByCodeResource.Replace(CodeSegment, code));
            response.EnsureSuccessStatusCode();

            return await MapContent<Country>(response);
        }

        private async Task<IEnumerable<CountryForPagination>> GetCountries()
        {
            if (_memoryCache.TryGetValue(CountriesCacheKey, out IEnumerable<CountryForPagination> inMemoryCountries))
            {
                return inMemoryCountries;
            }

            var response = await _httpClient.GetAsync(GetAllForPaginationResource);
            response.EnsureSuccessStatusCode();

            var countries = await MapContent<IEnumerable<CountryForPagination>>(response);

            _memoryCache.Set(CountriesCacheKey, countries);
            return countries;
        }

        private async Task<T> MapContent<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
