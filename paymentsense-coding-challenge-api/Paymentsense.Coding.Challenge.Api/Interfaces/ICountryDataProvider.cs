using System.Threading.Tasks;
using Paymentsense.Coding.Challenge.Api.Models;

namespace Paymentsense.Coding.Challenge.Api.Interfaces
{
    public interface ICountryDataProvider
    {
        Task<Country[]> GetCountryList();
    }
}
