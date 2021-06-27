using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Paymentsense.Coding.Challenge.Api.Models
{
    [BindProperties(SupportsGet = true)]
    public class CountryModel
    {
        [JsonPropertyName("currencies")] public CurrencyModel[] Currencies { get; set; }
        [JsonPropertyName("flag")] public string Flag { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("capital")] public string Capital { get; set; }
        [JsonPropertyName("population")] public int Population { get; set; }
        [JsonPropertyName("timezones")] public string[] Timezones { get; set; }
        [JsonPropertyName("borders")] public string[] Borders { get; set; }
        [JsonPropertyName("languages")] public Language[] Languages { get; set; }
    }
}