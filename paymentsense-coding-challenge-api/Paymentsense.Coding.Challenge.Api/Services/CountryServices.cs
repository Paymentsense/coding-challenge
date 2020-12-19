using Microsoft.Extensions.Configuration;
using Paymentsense.Coding.Challenge.Api.Common.Exceptions;
using Paymentsense.Coding.Challenge.Api.Core;
using Paymentsense.Coding.Challenge.Api.Models;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public class CountryServices : ICountryServices
    {

        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _configuration;

        public CountryServices(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService;
            _configuration = configuration;
        }
        public async Task<List<Country>> GetAllAsync()
        {

            try
            {

                var sourceUrl = _configuration.GetValue<string>("DataSource");

                // if we needed token it would be assigned to here.
                string token = "";

                // retrive data 
                var response = await _httpClientService.GetAsync(sourceUrl, token);


                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<List<Country>>(content);
                }

                throw  new ResourceNotFoundException("400", "System encountered a problem when connecting to remote server");
            }
            catch (Exception e)
            {
                throw new ResourceNotFoundException("400", e.Message);
            }
        }
    }
}
