using Microsoft.Extensions.Configuration;
using paymentsense.common.Contracts.Geographic;
using paymentsense.utility.CacheHelpers;
using paymentsense.utility.HtppHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace paymentsense.geographic.business
{
    public class Geographic : IGeographic
    {
        ICache _cache;
        IHttpHelpers _httpHelpers;
        string countryCacheKey = "lstcountry";
        string url = string.Empty;
        public Geographic(ICache cache, IHttpHelpers httpHelpers, IConfiguration config)
        {
            _cache = cache;
            _httpHelpers = httpHelpers;
            url = config.GetValue<string>("RestGetCountryBaseUrl");
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            List<Country> countries = new List<Country>();
            try
            {
                countries = _cache.Get<List<Country>>(countryCacheKey);
                if (countries == null || countries.Any() == false)
                {
                    countries = await _httpHelpers.Get<List<Country>>(url);
                    _cache.Set<List<Country>>(countryCacheKey,countries);
                }
            }
            catch (Exception ex)
            {
            }
            return countries;
        }
    }
}
