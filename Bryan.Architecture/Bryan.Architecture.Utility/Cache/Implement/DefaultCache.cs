using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Bryan.Architecture.Utility.Cache.Interface;

namespace Bryan.Architecture.Utility.Cache.Implement
{
    /// <summary>The default cache.</summary>
    public class DefaultCache : ICache
    {
        /// <summary>The _cache.</summary>
        private readonly ObjectCache _cache = MemoryCache.Default;

        /// <summary>The set.</summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiredTime">The expired time.</param>
        /// <param name="slidingExpiration">The sliding expiration.</param>
        /// <typeparam name="T">Object</typeparam>
        public void Set<T>(string key, T value, DateTime expiredTime, TimeSpan? slidingExpiration = null)
        {
            var policy = new CacheItemPolicy { AbsoluteExpiration = expiredTime.ToUniversalTime() };
            if (slidingExpiration.HasValue)
            {
                policy.SlidingExpiration = slidingExpiration.Value;
            }

            var cacheValue = Newtonsoft.Json.JsonConvert.SerializeObject(value);
            var item = new CacheItem(key, cacheValue);
            this._cache.Add(key, item, policy);
        }

        /// <summary>The remove.</summary>
        /// <param name="key">The key.</param>
        public void Remove(string key)
        {
            if (this._cache.Contains(key))
            {
                this._cache.Remove(key);
            }
        }

        /// <summary>The get.</summary>
        /// <param name="key">The key.</param>
        /// <typeparam name="T">Data</typeparam>
        /// <returns>The <see cref="T"/>.</returns>
        public T Get<T>(string key)
        {
            if (!this._cache.Contains(key))
            {
                return default(T);
            }

            var cacheValue = (this._cache.GetCacheItem(key).Value as CacheItem).Value.ToString();

            if (!string.IsNullOrEmpty(cacheValue))
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(cacheValue);
            }
            return default(T);
        }
    }
}