namespace Paymentsense.Coding.Challenge.Api.Core
{
    using System.Net.Http;
    using System.Threading.Tasks;
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> GetAsync(string url, string token);
    }
}