// ASP.NET.Plus
// Copyright (c) 2016 ZoneMatrix Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using AspNet.Plus.Logging.ReflectInsight;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Console.ReflectInsightSample
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.MinimumLevel = LogLevel.Debug;
            loggerFactory.AddReflectInsight();
            
            var logger = loggerFactory.CreateLogger<Program>();
            
            var exception = new Exception("Some Exception...");
            var logValues = new Dictionary<string, object>();
            logValues["key1"] = "value1";
            logValues["key2"] = "value2";
            logValues["key3"] = new { Name = "John", Age = 100 };

            logger.LogDebug("LogDebug");
            logger.LogDebug("LogDebug", exception);
            logger.LogDebug(logValues, "LogDebug", exception);
            logger.LogDebug(logValues, exception);

            logger.LogVerbose("LogVerbose");
            logger.LogVerbose("LogVerbose", exception);
            logger.LogVerbose(logValues, "LogVerbose", exception);
            logger.LogVerbose(logValues, exception);

            logger.LogInformation("LogInformation");
            logger.LogInformation("LogInformation", exception);
            logger.LogInformation(logValues, "LogInformation", exception);
            logger.LogInformation(logValues, exception);
            
            logger.LogWarning("LogWarning");
            logger.LogWarning("LogWarning", exception);
            logger.LogWarning(logValues, "LogWarning", exception);
            logger.LogWarning(logValues, exception);
            
            logger.LogError("LogError");
            logger.LogError("LogError", exception);
            logger.LogError(logValues, "LogError", exception);
            logger.LogError(logValues, exception);

            logger.LogCritical("LogCritical");
            logger.LogCritical("LogCritical", exception);
            logger.LogCritical(logValues, "LogCritical", exception);
            logger.LogCritical(logValues, exception);

            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();        
        }
    }
}
