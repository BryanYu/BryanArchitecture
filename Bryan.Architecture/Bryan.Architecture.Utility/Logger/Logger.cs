using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Bryan.Architecture.Utility.Logger.Enum;
using NLog;

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
        public static void Log(LoggerLevel level, Exception exception = null, string message = "")
        {
            var logLevel = GetLogLevel(level);
            _logger.Log(logLevel, exception, message);
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