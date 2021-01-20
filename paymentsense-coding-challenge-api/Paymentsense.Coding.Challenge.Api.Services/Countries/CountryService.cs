using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services.Countries
{
    public class CountryService : ICountryService
    {
        private readonly ICachedCountryService cachedCountryService;

        public CountryService(ICachedCountryService cachedCountryService)
        {
            this.cachedCountryService = cachedCountryService;
        }

        public async Task<List<CountryBasic>> GetCountriesBasicAsync()
        {
            var countries = await cachedCountryService.GetCountriesAsync().ConfigureAwait(false);
            return countries.Select(x => new CountryBasic() { Name = x.Name, Flag = x.Flag }).ToList();
        }

        public async Task<Country> GetCountryAsync(string countryName)
        {
            var countries = await cachedCountryService.GetCountriesAsync().ConfigureAwait(false);
            return countries.FirstOrDefault(x => x.Name == countryName);
        }
    }
}
