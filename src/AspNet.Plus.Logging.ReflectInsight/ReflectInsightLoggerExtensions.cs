// ASP.NET.Plus
// Copyright (c) 2016 ZoneMatrix Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Microsoft.Extensions.Logging;
using System;

namespace AspNet.Plus.Logging.ReflectInsight
{
    /// <summary>
    /// 
    /// </summary>
    public static class ReflectInsightLoggerExtensions
    {
        /// <summary>
        /// Logs the information.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static ILogger LogInformation(this ILogger logger, Exception ex, string message = null, params object[] args)
        {
            logger.LogInformation(new EventId(0), ex, message ?? ex.Message, args);
            return logger;
        }

        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static ILogger LogWarning(this ILogger logger, Exception ex, string message = null, params object[] args)
        {
            logger.LogWarning(new EventId(0), ex, message ?? ex.Message, args);
            return logger;
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static ILogger LogError(this ILogger logger, Exception ex, string message = null, params object[] args)
        {
            logger.LogError(new EventId(0), ex, message ?? ex.Message, args);
            return logger;
        }

        /// <summary>
        /// Logs the critical.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="ex">The ex.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static ILogger LogCritical(this ILogger logger, Exception ex, string message = null, params object[] args)
        {
            logger.LogCritical(new EventId(0), ex, message ?? ex.Message, args);
            return logger;
        }
    }
}
