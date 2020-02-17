
using Microsoft.Extensions.Caching.Memory;
using System;

namespace paymentsense.utility.CacheHelpers
{
    public class InMemoryCache : ICache
    {
        private readonly IMemoryCache _memoryCache;
        public InMemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T Get<T>(string key)
        {
            T data = default(T);
            if (_memoryCache.TryGetValue(key, out var outObj))
            {
                data = (T)outObj;
            }
            return data;
        }

        public bool Set<T>(string key, T data)
        {
            bool bIsSuccess = false;
            var cacheEntryOptions = new MemoryCacheEntryOptions()
           .SetSlidingExpiration(TimeSpan.FromMinutes(60));
            var result = _memoryCache.Set(key, data, cacheEntryOptions);
            if (result != null)
            {
                bIsSuccess = true;
            }
            return bIsSuccess;
        }
    }
}
