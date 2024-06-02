using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SANYUKT.Commonlib.Cache
{
    public static class MemoryCachingService
    {
        public static IMemoryCache memoryCache;

        static MemoryCachingService()
        {
            memoryCache = null;
        }

        public async static Task Clear(string key)
        {
            await Task.Run(() =>
            {
                if (!string.IsNullOrEmpty(key))
                    memoryCache.Remove(key);
            });
        }

        public async static Task ClearAll()
        {
            throw new NotImplementedException();
        }

        public async static Task<T> Get<T>(string key, bool persistForMaxTime = false)
        {
            var value = default(T);
            await Task.Run(() =>
            {
                if (!string.IsNullOrEmpty(key))
                    value = memoryCache.Get<T>(key);
            });

            return value;
        }

        public async static Task Put<T>(string key, T value, bool persistForMaxTimeOut = false)
        {
            await Task.Run(() =>
            {
                if (!string.IsNullOrEmpty(key))
                    memoryCache.Set(key, value, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(15)));
            });
        }
    }
}
