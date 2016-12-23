﻿// ASP.NET.Plus
// Copyright (c) 2016 ASP.NET Plus.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Microsoft.Extensions.Logging;

namespace AspNet.Plus.Logging.ReflectInsight
{
    /// <summary>
    /// 
    /// </summary>
    public static class ReflectInsightLoggerFactoryExtensions
    {
        /// <summary>
        /// Adds the reflect insight.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="configFile">The configuration file.</param>
        /// <returns></returns>
        public static ILoggerFactory AddReflectInsight(this ILoggerFactory factory, string configFile = "ReflectInsight.config")
        {
            factory.AddProvider(new ReflectInsightLoggerProvider(configFile));
            return factory;
        }
    }
}
