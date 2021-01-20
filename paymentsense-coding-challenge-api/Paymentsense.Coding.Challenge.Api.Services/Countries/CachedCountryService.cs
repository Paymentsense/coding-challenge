using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services.Caching;
using Paymentsense.Coding.Challenge.Api.Services.HttpClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services.Countries
{
    public class CachedCountryService : ICachedCountryService
    {
        private const string AllCountriesRelativeUrl = "all";

        private readonly IRestClient restClient;

        private readonly ICacheService cacheService;

        private readonly AppSettings settings;

        public CachedCountryService(IRestClient restClient,
            IOptions<AppSettings> settings,
            ICacheService cacheService)
        {
            this.restClient = restClient;
            this.cacheService = cacheService;
            this.settings = settings.Value;
        }

        public Task<List<Country>> GetCountriesAsync()
        {
            Func<Task<List<Country>>> func = async () =>
            {
                var result = await restClient
                    .GetAsync(Path.Combine(settings.RestCountriesUrl, AllCountriesRelativeUrl))
                    .ConfigureAwait(false);

                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<Country>>(result.Response);
                }

                return new List<Country>();
            };

            return cacheService.GetAsync(nameof(CountryService), func, settings.CacheTimeInSeconds);
        }
    }
}
