using Microsoft.Extensions.DependencyInjection;
using paymentsense.utility.CacheHelpers;
using paymentsense.utility.HtppHelpers;

namespace paymentsense.utility
{
    public static class Bootstrapper
    {
        public static void UseUtilityServices(this IServiceCollection services)
        {
            services.AddHttpClient<IHttpHelpers, HttpHelpers>();
            services.AddSingleton<ICache, InMemoryCache>();
        }
    }
}
