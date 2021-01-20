using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Services.Caching;
using Paymentsense.Coding.Challenge.Api.Services.Countries;
using Paymentsense.Coding.Challenge.Api.Services.HttpClient;
using System;
using System.Net.Http;

namespace Paymentsense.Coding.Challenge.Api
{
    public class Startup
    {
        readonly string CorsPolicyName = "PaymentsenseCodingChallengeOriginPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHealthChecks();

            services.AddOptions();

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicyName,
                    builder =>
                    {
                        builder
                            .WithOrigins(appSettings.CorsOrigin.Split(",", StringSplitOptions.RemoveEmptyEntries))
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            services.AddMemoryCache();

            services.AddSingleton<HttpClient, HttpClient>();
            services.AddSingleton<IRestClient, RestClient>();
            services.AddSingleton<ICachedCountryService, CachedCountryService>();
            services.AddSingleton<ICountryService, CountryService>();
            services.AddSingleton<ICacheService, CacheService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(CorsPolicyName);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
