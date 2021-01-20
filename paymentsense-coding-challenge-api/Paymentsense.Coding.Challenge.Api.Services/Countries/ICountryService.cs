using Paymentsense.Coding.Challenge.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services.Countries
{
    public interface ICountryService
    {
        Task<Country> GetCountryAsync(string countryName);

        Task<List<CountryBasic>> GetCountriesBasicAsync();
    }
}
