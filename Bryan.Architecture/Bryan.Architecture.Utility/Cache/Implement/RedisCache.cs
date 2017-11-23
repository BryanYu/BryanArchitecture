using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bryan.Architecture.Utility.Cache.Interface;

using StackExchange.Redis;

namespace Bryan.Architecture.Utility.Cache.Implement
{
    /// <summary>The redis cache.</summary>
    public class RedisCache : ICache
    {
        private ConnectionMultiplexer _redis;

        private IDatabase _db;

        public RedisCache(int databaseNumber, string configuration)
        {
            this._redis = ConnectionMultiplexer.Connect(configuration);
            this._db = this._redis.GetDatabase(databaseNumber);
        }

        /// <summary>The set.</summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiredTime">The expired time.</param>
        /// <param name="slidingExpiration">The sliding expiration.</param>
        /// <typeparam name="T">Data</typeparam>
        public void Set<T>(string key, T value, DateTime expiredTime, TimeSpan? slidingExpiration = null)
        {
            var expireTimeSpan = expiredTime.ToUniversalTime().Subtract(DateTime.UtcNow);
            if (typeof(T).IsValueType)
            {
                this._db.StringSet(key, value.ToString(), expireTimeSpan);
            }
        }

        /// <summary>The remove.</summary>
        /// <param name="key">The key.</param>
        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        /// <summary>The get.</summary>
        /// <param name="key">The key.</param>
        /// <typeparam name="T">Data</typeparam>
        /// <returns>The <see cref="T"/>.</returns>
        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }
    }
}