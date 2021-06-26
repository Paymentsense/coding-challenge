using System.Collections.Generic;
using Paymentsense.Coding.Challenge.Api.Models;

namespace Paymentsense.Coding.Challenge.Api.Clients
{
    public class CountryCache : ICountryCache
    {
        private static List<CountryModel> Countries { get; set; } = new List<CountryModel>();

        public List<CountryModel> GetCountries()
        {
            return Countries;
        }

        public void PopulateCountries(List<CountryModel> countries)
        {
            Countries = countries;
        }
    }
}