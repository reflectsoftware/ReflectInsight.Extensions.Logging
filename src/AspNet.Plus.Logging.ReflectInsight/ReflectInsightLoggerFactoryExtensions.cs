// ASP.NET.Plus
// Copyright (c) 2016 ZoneMatrix Inc.
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
        /// <returns></returns>
        public static ILoggerFactory AddReflectInsight(this ILoggerFactory factory)
        {
            factory.AddProvider(new ReflectInsightLoggerProvider());
            return factory;
        }
    }
}
