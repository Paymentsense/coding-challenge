using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Paymentsense.Coding.Challenge.Api.Clients;
using Paymentsense.Coding.Challenge.Api.Models;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Clients
{
    public class CountryCacheTests
    {
        private readonly List<CountryModel> _countriesMock;

        public CountryCacheTests()
        {
            var country = new CountryModel
            {
                Name = "Test Country",
                Flag = "flag",
                Population = 123456,
                Timezones = new[] {"UTC", "UTC+01:00"},
                Languages = new[] {new Language() {Name = "English"}},
                Currencies = new[] {new CurrencyModel() {Name = "GBP"}},
                Capital = "London",
                Borders = new[] {"IRL"}
            };

            _countriesMock = Enumerable.Range(1, 100).Select(x => country).ToList();
        }

        [Fact]
        public void GetCountries_ReturnsEmptyList()
        {
            var cache = new CountryCache();
            var result = cache.GetCountries();

            result.Should().BeOfType<List<CountryModel>>();
            result.Should().HaveCount(0);
        }

        [Fact]
        public void PopulateCountries_PopulatesCountries()
        {
            var cache = new CountryCache();
            cache.PopulateCountries(_countriesMock);
            var result = cache.GetCountries();

            result.Should().BeOfType<List<CountryModel>>();
            result.Should().HaveCount(_countriesMock.Count);
            result.Should().BeSameAs(_countriesMock);
        }
    }
}