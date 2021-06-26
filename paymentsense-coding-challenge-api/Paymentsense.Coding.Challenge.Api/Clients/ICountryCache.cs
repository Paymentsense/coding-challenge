using System.Collections.Generic;
using Paymentsense.Coding.Challenge.Api.Models;

namespace Paymentsense.Coding.Challenge.Api.Clients
{
    public interface ICountryCache
    {
        public List<CountryModel> GetCountries();
        public void PopulateCountries(List<CountryModel> countries);
    }
}