using System.Collections.Generic;
using Paymentsense.Coding.Challenge.Api.Models;

namespace Paymentsense.Coding.Challenge.Api.Clients
{
    public class CountryCache : ICountryCache
    {
        private static List<CountryModel> Countries { get; set; } = new List<CountryModel>();
        private static readonly object CountriesLock = new object();

        public List<CountryModel> GetCountries()
        {
            lock (CountriesLock)
            {
                return Countries;
            }
        }

        public void PopulateCountries(List<CountryModel> countries)
        {
            lock (CountriesLock)
            {
                Countries = countries;
            }
        }
    }
}