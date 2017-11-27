using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Bryan.Architecture.Utility.Logger.Enum;

using Newtonsoft.Json;

using NLog;
using NLog.Layouts;

namespace Bryan.Architecture.Utility.Logger
{
    /// <summary>The logger factory.</summary>
    public static class Logger
    {
        /// <summary>The _logger.</summary>
        private static NLog.ILogger _logger = LogManager.GetCurrentClassLogger();

        /// <summary>The log.</summary>
        /// <param name="level">The level.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The arguments.</param>
        public static void Log(LoggerLevel level, Exception exception = null, string message = "", object arguments = null)
        {
            var logLevel = GetLogLevel(level);
            LogManager.Configuration.Variables["Arguments"] = GetArguments(arguments);
            _logger.Log(logLevel, exception, message);
        }

        /// <summary>The get arguments.</summary>
        /// <param name="arguments">The arguments.</param>
        /// <returns>The <see cref="string"/>.</returns>
        private static string GetArguments(object arguments)
        {
            if (arguments == null)
            {
                return string.Empty;
            }

            var argumentArray = arguments as object[];
            if (argumentArray != null)
            {
                var result = argumentArray.Select(argument => JsonConvert.SerializeObject(argument)).ToList();
                return string.Join(",", result);
            }

            return JsonConvert.SerializeObject(arguments);
        }

        /// <summary>The get log level.</summary>
        /// <param name="level">The level.</param>
        /// <returns>The <see cref="LogLevel"/>.</returns>
        /// <exception cref="ArgumentException">ArgumentException</exception>
        private static LogLevel GetLogLevel(LoggerLevel level)
        {
            switch (level)
            {
                case LoggerLevel.Debug:
                    return LogLevel.Debug;

                case LoggerLevel.Trace:
                    return LogLevel.Trace;

                case LoggerLevel.Info:
                    return LogLevel.Info;

                case LoggerLevel.Warn:
                    return LogLevel.Warn;

                case LoggerLevel.Error:
                    return LogLevel.Error;

                case LoggerLevel.Fatal:
                    return LogLevel.Fatal;

                default: throw new ArgumentException("Argument not found");
            }
        }
    }
}