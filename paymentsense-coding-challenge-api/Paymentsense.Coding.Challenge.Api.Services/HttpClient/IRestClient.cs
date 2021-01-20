using System.Net.Http;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services.HttpClient
{
    public interface IRestClient
    {
        Task<RestResponse> GetAsync(string url);
    }
}
