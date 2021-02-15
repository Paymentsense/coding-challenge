using System.Collections.Generic;
using System.Threading.Tasks;
using Paymentsense.Coding.Challenge.Api.Models;

namespace Paymentsense.Coding.Challenge.Api.Services
{
    public interface ICountriesRestService
    {
        Task<CountryForPaginationResponse> GetAllForPagination(int page, int take);
        Task<Country> GetByCode(string code);
    }
}