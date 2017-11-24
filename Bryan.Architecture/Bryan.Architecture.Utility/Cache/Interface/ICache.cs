using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bryan.Architecture.Utility.Cache.Interface
{
    /// <summary>The Cache interface.</summary>
    public interface ICache
    {
        /// <summary>The set.</summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="expiredTime">The expired time.</param>
        /// <typeparam name="T">Data</typeparam>
        void Set<T>(string key, T value, DateTime expiredTime);

        /// <summary>The remove.</summary>
        /// <param name="key">The key.</param>
        void Remove(string key);

        /// <summary>The get.</summary>
        /// <param name="key">The key.</param>
        /// <typeparam name="T">Data</typeparam>
        /// <returns>The <see cref="T"/>.</returns>
        T Get<T>(string key);
    }
}