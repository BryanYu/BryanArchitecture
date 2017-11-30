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
        /// <summary>The _db.</summary>
        private IDatabase _db;

        /// <summary>Gets the db.</summary>
        private IDatabase DB
        {
            get
            {
                if (this._db == null)
                {
                    this._db = ConnectionMultiplexer.Connect($"{this._host}:{this._port},password={this._password},connectTimeout={500}")
                        .GetDatabase(this._databaseNumber);
                }

                return this._db;
            }
        }

        /// <summary>The _database number.</summary>
        private int _databaseNumber;

        /// <summary>The _host.</summary>
        private string _host;

        /// <summary>The _port.</summary>
        private string _port;

        /// <summary>The _password.</summary>
        private string _password;

        /// <summary>Initializes a new instance of the <see cref="RedisCache"/> class.</summary>
        /// <param name="databaseNumber">The database number.</param>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        /// <param name="password">The password.</param>
        public RedisCache(int databaseNumber, string host, string port = "6379", string password = "")
        {
            this._databaseNumber = databaseNumber;
            this._host = host;
            this._port = port;
            this._password = password;
        }

        /// <summary>The set.</summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiredSecond">The expired second.</param>
        /// <typeparam name="T">Data</typeparam>
        public void Set<T>(string key, T value, int expiredSecond = 1800)
        {
            var expireTimeSpan = TimeSpan.FromSeconds(expiredSecond);
            var jsonValue = Newtonsoft.Json.JsonConvert.SerializeObject(value);
            this.DB.StringSet(key, jsonValue, expireTimeSpan);
        }

        /// <summary>The remove.</summary>
        /// <param name="key">The key.</param>
        public void Remove(string key)
        {
            this.DB.KeyDelete(key);
        }

        /// <summary>The get.</summary>
        /// <param name="key">The key.</param>
        /// <typeparam name="T">Data</typeparam>
        /// <returns>The <see cref="T"/>.</returns>
        public T Get<T>(string key)
        {
            var value = this.DB.StringGet(key);
            if (!string.IsNullOrEmpty(value))
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(value);
            }

            return default(T);
        }
    }
}