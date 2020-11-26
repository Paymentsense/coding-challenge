using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using paymentsense.geographic.business;
using paymentsense.utility;
using Paymentsense.Coding.Challenge.Api.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Paymentsense.Coding.Challenge.Api.Tests.Controllers
{
    
    public class GeographicControllerTests
    {
        private IServiceCollection services;
        private IServiceProvider serviceProvider;
        public GeographicControllerTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);
            var configuration = builder.Build();
            services = new ServiceCollection();
            services.UseGeoGraphicServices();
            services.AddMemoryCache();
            services.AddSingleton<IConfiguration>(configuration);
            serviceProvider = services.BuildServiceProvider();

        }

        [Fact]
        public void Get_OnInvoke_ReturnsExpectedMessage()
        {
            var controller = new GeographicController(serviceProvider.GetRequiredService<IGeographic>());

            var result = controller.GetCountries().Result as OkObjectResult;

            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().NotBeNull();
        }
    }
}
