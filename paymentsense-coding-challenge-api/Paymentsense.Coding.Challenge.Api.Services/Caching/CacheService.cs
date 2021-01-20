using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Paymentsense.Coding.Challenge.Api.Services.Caching
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache memorycache)
        {
            _cache = memorycache;
        }

        public Task<T> GetAsync<T>(object key, Func<Task<T>> callback, int cacheTimeInSeconds)
        {
            return _cache.GetOrCreateAsync(key, (entry) =>
            {
                entry.SlidingExpiration = TimeSpan.FromSeconds(cacheTimeInSeconds);
                return callback();
            });
        }
    }
}
