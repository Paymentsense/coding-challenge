using System;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services.Caching
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(object key, Func<Task<T>> callback, int cacheTimeInSeconds);
    }
}
