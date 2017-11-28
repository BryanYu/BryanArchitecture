using System;
using System.Linq;
using System.Reflection;
using Bryan.Architecture.Utility.Attributes;
using Bryan.Architecture.Utility.Cache.Interface;
using Bryan.Architecture.Utility.Logger;
using Bryan.Architecture.Utility.Logger.Enum;
using Castle.DynamicProxy;
using Newtonsoft.Json;

namespace Bryan.Architecture.BusinessLogic.Interceptor
{
    /// <summary>The log interceptor.</summary>
    public class BllInterceptor : IInterceptor
    {
        /// <summary>The cache.</summary>
        private ICache _cache;

        /// <summary>Initializes a new instance of the <see cref="BllInterceptor"/> class.</summary>
        /// <param name="cache">The cache.</param>
        public BllInterceptor(ICache cache)
        {
            this._cache = cache;
        }

        /// <summary>The intercept.</summary>
        /// <param name="invocation">The invocation.</param>
        public void Intercept(IInvocation invocation)
        {
            var logAttribute = invocation.MethodInvocationTarget.GetCustomAttributes(typeof(LogAttribute)).FirstOrDefault() as LogAttribute;
            if (logAttribute != null)
            {
                this.LogProcess(invocation, logAttribute);
            }

            var cacheAttribute = invocation.MethodInvocationTarget.GetCustomAttributes(typeof(CacheAttribute))
                                     .FirstOrDefault() as CacheAttribute;
            if (cacheAttribute != null)
            {
                this.CacheProcess(invocation, cacheAttribute.ExpiredSecond);
            }
        }

        /// <summary>The log.</summary>
        /// <param name="invocation">The invocation.</param>
        /// <param name="logAttribute">The log attribute.</param>
        private void LogProcess(IInvocation invocation, LogAttribute logAttribute)
        {
            var message = string.IsNullOrEmpty(logAttribute.Message)
                              ? $"Call Method {invocation.Method.Name}"
                              : logAttribute.Message;
            var endMessage = string.IsNullOrEmpty(logAttribute.Message)
                                 ? $"End Method{invocation.Method.Name}"
                                 : logAttribute.Message;

            try
            {
                if (logAttribute.IsLogArguments)
                {
                    Logger.Log(logAttribute.Level, message: message, arguments: invocation.Arguments);
                    invocation.Proceed();
                    Logger.Log(LoggerLevel.Trace, message: endMessage, arguments: invocation.ReturnValue);
                }
                else
                {
                    Logger.Log(logAttribute.Level, message: message);
                    invocation.Proceed();
                    Logger.Log(logAttribute.Level, message: endMessage);
                }
            }
            catch (Exception e)
            {
                Logger.Log(LoggerLevel.Error, e, arguments: invocation.Arguments);
                throw e;
            }
        }

        /// <summary>The cache process.</summary>
        /// <param name="invocation">The invocation.</param>
        /// <param name="expiredSecond">The expired second.</param>
        private void CacheProcess(IInvocation invocation, int expiredSecond)
        {
            var cacheKey = this.GetCacheKey(invocation);
            var cacheValue = this._cache.Get<object>(cacheKey);
            if (cacheValue != null)
            {
                invocation.ReturnValue = cacheValue;
            }
            else
            {
                this._cache.Set(cacheKey, invocation.ReturnValue, expiredSecond);
            }
        }

        /// <summary>The get cache key.</summary>
        /// <param name="invocation">The invocation.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private string GetCacheKey(IInvocation invocation)
        {
            return $"{invocation.TargetType.Name}.{invocation.MethodInvocationTarget.Name}.{JsonConvert.SerializeObject(invocation.Arguments)}";
        }
    }
}