// ASP.NET.Plus
// Copyright (c) 2016 ZoneMatrix Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using System;
using System.Collections.Generic;

namespace AspNet.Plus.Logging.ReflectInsight
{
    /// <summary>
    /// 
    /// </summary>
    public static class ReflectInsightLoggerExtensions
    {
        /// <summary>
        /// Messages the formatter.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="error">The error.</param>
        /// <returns></returns>
        private static string MessageFormatter(object state, Exception error)
        { 
            return state.ToString(); 
        }

        /// <summary>
        /// Gets the log values.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public static ILogValues GetLogValues(this ILogger logger, IEnumerable<KeyValuePair<string, object>> values)
        {            
            return new ReflectInsightLogValues(values);
        }

        //------------------------------- DEBUG ----------------------------------------//

        /// <summary>
        /// Logs the debug.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="values">The values.</param>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        public static ILogger LogDebug(this ILogger logger, IEnumerable<KeyValuePair<string, object>> values, Exception ex)
        {
            logger.LogDebug(new ReflectInsightLogValues(values, ex.Message), ex);
            return logger;
        }

        /// <summary>
        /// Logs the debug.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static ILogger LogDebug(this ILogger logger, int eventId, string message, Exception ex, params object[] args)
        {
            logger.Log(LogLevel.Debug, eventId, new FormattedLogValues(message, args), ex, MessageFormatter);
            return logger;
        }

        /// <summary>
        /// Logs the debug.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static ILogger LogDebug(this ILogger logger, string message, Exception ex, params object[] args)
        {
            logger.Log(LogLevel.Debug, 0, new FormattedLogValues(message, args), ex, MessageFormatter);
            return logger;
        }

        //------------------------------- VERBOSE ----------------------------------------//

        /// <summary>
        /// Logs the verbose.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="values">The values.</param>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        public static ILogger LogVerbose(this ILogger logger, IEnumerable<KeyValuePair<string, object>> values, Exception ex)
        {
            logger.LogVerbose(new ReflectInsightLogValues(values, ex.Message), ex);
            return logger;
        }

        /// <summary>
        /// Logs the verbose.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static ILogger LogVerbose(this ILogger logger, int eventId, string message, Exception ex, params object[] args)
        {
            logger.Log(LogLevel.Verbose, eventId, new FormattedLogValues(message, args), ex, MessageFormatter);
            return logger;
        }

        /// <summary>
        /// Logs the verbose.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static ILogger LogVerbose(this ILogger logger, string message, Exception ex, params object[] args)
        {
            logger.Log(LogLevel.Verbose, 0, new FormattedLogValues(message, args), ex, MessageFormatter);
            return logger;
        }

        //------------------------------- INFORMATON ----------------------------------------//

        /// <summary>
        /// Logs the information.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="values">The values.</param>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        public static ILogger LogInformation(this ILogger logger, IEnumerable<KeyValuePair<string, object>> values, Exception ex)
        {
            logger.LogInformation(new ReflectInsightLogValues(values, ex.Message), ex);
            return logger;
        }

        /// <summary>
        /// Logs the information.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static ILogger LogInformation(this ILogger logger, int eventId, string message, Exception ex, params object[] args)
        {
            logger.Log(LogLevel.Information, eventId, new FormattedLogValues(message, args), ex, MessageFormatter);
            return logger;
        }

        /// <summary>
        /// Logs the information.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="message">The message.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static ILogger LogInformation(this ILogger logger, string message, Exception ex, params object[] args)
        {
            logger.Log(LogLevel.Information, 0, new FormattedLogValues(message, args), ex, MessageFormatter);
            return logger;
        }

        //------------------------------- WARNING ----------------------------------------//

        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="values">The values.</param>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        public static ILogger LogWarning(this ILogger logger, IEnumerable<KeyValuePair<string, object>> values, Exception ex)
        {
            logger.LogWarning(new ReflectInsightLogValues(values, ex.Message), ex);
            return logger;
        }


        //------------------------------- ERROR ----------------------------------------//

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="values">The values.</param>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        public static ILogger LogError(this ILogger logger, IEnumerable<KeyValuePair<string, object>> values, Exception ex)
        {
            logger.LogError(new ReflectInsightLogValues(values, ex.Message), ex);
            return logger;
        }


        //------------------------------- CRITICAL ----------------------------------------//

        /// <summary>
        /// Logs the critical.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="values">The values.</param>
        /// <param name="ex">The ex.</param>
        /// <returns></returns>
        public static ILogger LogCritical(this ILogger logger, IEnumerable<KeyValuePair<string, object>> values, Exception ex)
        {
            logger.LogCritical(new ReflectInsightLogValues(values, ex.Message), ex);
            return logger;
        }

    }
}
