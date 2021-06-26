namespace Paymentsense.Coding.Challenge.Api.Models
{
    public class CountryModel
    {
        public CurrencyModel[] currencies { get; set; }
        public string flag { get; set; }
        public string name { get; set; }
        public string capital { get; set; }
        public int population { get; set; }
        public string[] timezones { get; set; }
        public string[] borders { get; set; }
    }
}