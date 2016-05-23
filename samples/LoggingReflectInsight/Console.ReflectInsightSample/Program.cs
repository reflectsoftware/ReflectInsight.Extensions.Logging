// ASP.NET.Plus
// Copyright (c) 2016 ZoneMatrix Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using AspNet.Plus.Logging.ReflectInsight;
using Microsoft.Extensions.Logging;
using System;

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
            loggerFactory.AddReflectInsight();
            
            var logger = loggerFactory.CreateLogger<Program>();
            var exception = new Exception("Some exception");
            
            logger.LogDebug("LogDebug with some args: {0}, {2}", 1, 2);
            logger.LogTrace("LogTrace with some args: {0}, {2}", 1, 2);

            logger.LogInformation("LogInformation with some args: {0}, {2}", 1, 2);
            logger.LogInformation(exception, "LogInformation with exception and some args: {0}, {2}", 1, 2);
            logger.LogInformation(exception);

            logger.LogWarning("LogWarning with some args: {0}, {2}", 1, 2);
            logger.LogWarning(exception, "LogWarning with exception and some args: {0}, {2}", 1, 2); ;
            logger.LogWarning(exception);

            logger.LogError("LogError with some args: {0}, {2}", 1, 2);
            logger.LogError(exception, "LogError with exception and some args: {0}, {2}", 1, 2);
            logger.LogError(exception);

            logger.LogCritical("LogCritical with some args: {0}, {2}", 1, 2);
            logger.LogCritical(exception, "LogCritical with exception and some args: {0}, {2}", 1, 2);
            logger.LogCritical(exception);

            System.Console.WriteLine("Press any key to continue...");
            System.Console.ReadKey();        
        }
    }
}
