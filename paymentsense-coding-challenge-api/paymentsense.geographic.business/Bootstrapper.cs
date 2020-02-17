using Microsoft.Extensions.DependencyInjection;
using paymentsense.utility;

namespace paymentsense.geographic.business
{
    public static class Bootstrapper
    {
        public static void UseGeoGraphicServices(this IServiceCollection services)
        {
            services.UseUtilityServices();
            services.AddSingleton<IGeographic, Geographic>();
        }
    }
}
