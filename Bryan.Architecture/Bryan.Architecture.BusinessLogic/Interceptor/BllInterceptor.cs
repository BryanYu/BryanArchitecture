using System;
using System.CodeDom;
using System.Linq;
using System.Reflection;
using Bryan.Architecture.Utility.Attributes;
using Bryan.Architecture.Utility.Cache.Interface;
using Bryan.Architecture.Utility.Logger;
using Bryan.Architecture.Utility.Logger.Enum;
using Castle.DynamicProxy;

namespace Bryan.Architecture.BusinessLogic.Interceptor
{
    /// <summary>The log interceptor.</summary>
    public class BllInterceptor : IInterceptor
    {
        /// <summary>The cache.</summary>
        public ICache Cache;

        /// <summary>The intercept.</summary>
        /// <param name="invocation">The invocation.</param>
        public void Intercept(IInvocation invocation)
        {
            var logAttribute = invocation.MethodInvocationTarget.GetCustomAttributes(typeof(LogAttribute)).FirstOrDefault() as LogAttribute;
            if (logAttribute != null)
            {
                this.Log(invocation, logAttribute);
            }
        }

        /// <summary>The log.</summary>
        /// <param name="invocation">The invocation.</param>
        /// <param name="logAttribute">The log attribute.</param>
        private void Log(IInvocation invocation, LogAttribute logAttribute)
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

                var cacheAttribute = invocation.MethodInvocationTarget.GetCustomAttributes(typeof(CacheAttribute))
                                         .FirstOrDefault() as CacheAttribute;

                if (cacheAttribute != null)
                {
                    this.Cache.Set(cacheAttribute.Key, invocation.ReturnValue, cacheAttribute.ExpiredMinutes);
                }
            }
            catch (Exception e)
            {
                Logger.Log(LoggerLevel.Error, e, arguments: invocation.Arguments);
                throw e;
            }
        }
    }
}