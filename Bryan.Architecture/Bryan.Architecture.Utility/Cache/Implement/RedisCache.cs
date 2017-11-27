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
        /// <summary>The _redis.</summary>
        private IConnectionMultiplexer _redis;

        /// <summary>The _db.</summary>
        private IDatabase _db;

        /// <summary>Initializes a new instance of the <see cref="RedisCache"/> class.</summary>
        /// <param name="databaseNumber">The database number.</param>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        /// <param name="password">The password.</param>
        public RedisCache(int databaseNumber, string host, string port = "6379", string password = "")
        {
            this._redis = ConnectionMultiplexer.Connect($"{host}:{port},password={password}");
            this._db = this._redis.GetDatabase(databaseNumber);
        }

        /// <summary>The set.</summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiredMinutes">The expired minutes.</param>
        /// <typeparam name="T">Data</typeparam>
        public void Set<T>(string key, T value, int expiredMinutes = 30)
        {
            var expireTimeSpan = TimeSpan.FromMinutes(expiredMinutes);
            var jsonValue = Newtonsoft.Json.JsonConvert.SerializeObject(value);
            this._db.StringSet(key, jsonValue, expireTimeSpan);
        }

        /// <summary>The remove.</summary>
        /// <param name="key">The key.</param>
        public void Remove(string key)
        {
            this._db.KeyDelete(key);
        }

        /// <summary>The get.</summary>
        /// <param name="key">The key.</param>
        /// <typeparam name="T">Data</typeparam>
        /// <returns>The <see cref="T"/>.</returns>
        public T Get<T>(string key)
        {
            var value = this._db.StringGet(key);
            if (!string.IsNullOrEmpty(value))
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
            }

            return default(T);
        }
    }
}