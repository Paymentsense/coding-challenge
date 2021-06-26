using System.Collections.Generic;
using System.Threading.Tasks;
using Paymentsense.Coding.Challenge.Api.Models;

namespace Paymentsense.Coding.Challenge.Api.Clients
{
    public interface ICountriesApiClient
    {
        public Task<List<CountryModel>> GetCountries();
    }
}