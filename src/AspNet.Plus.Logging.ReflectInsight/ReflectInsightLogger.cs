// ASP.NET.Plus
// Copyright (c) 2016 ZoneMatrix Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Microsoft.Extensions.Logging;
using ReflectSoftware.Insight;
using ReflectSoftware.Insight.Common;
using RI.Utils.ExceptionManagement;
using System;

namespace AspNet.Plus.Logging.ReflectInsight
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Logging.ILogger" />
    public class ReflectInsightLogger : ILogger
    {
        private readonly string _name;

        private class NoopDisposable : IDisposable
        {
            public static Lazy<NoopDisposable> Instance = new Lazy<NoopDisposable>(() => new NoopDisposable());

            public void Dispose()
            {
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReflectInsightLogger"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public ReflectInsightLogger(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Begins a logical operation scope.
        /// </summary>
        /// <param name="state">The identifier for the scope.</param>
        /// <returns>
        /// An IDisposable that ends the logical operation scope on dispose.
        /// </returns>
        public IDisposable BeginScopeImpl(object state)
        {
            return NoopDisposable.Instance.Value;
        }

        /// <summary>
        /// Checks if the given LogLevel is enabled.
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        /// <summary>
        /// Aggregates most logging patterns to a single method.
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="eventId"></param>
        /// <param name="state"></param>
        /// <param name="exception"></param>
        /// <param name="formatter"></param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel) || logLevel == LogLevel.None)
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            var message = formatter(state, null);

            if (string.IsNullOrEmpty(message))
            {
                return;
            }

            var methodType = MessageType.Clear;
            switch (logLevel)
            {
                case LogLevel.Verbose:
                    methodType = MessageType.SendVerbose;
                    break;

                case LogLevel.Debug:
                    methodType = MessageType.SendDebug;
                    break;

                case LogLevel.Information:
                    methodType = MessageType.SendInformation;
                    break;

                case LogLevel.Warning:
                    methodType = MessageType.SendWarning;
                    break;

                case LogLevel.Error:
                    methodType = MessageType.SendError;
                    break;

                case LogLevel.Critical:
                    methodType = MessageType.SendFatal;
                    break;
            }

            var details = (string)null;
            if (exception != null)
            {
                details = ExceptionBasePublisher.ConstructIndentedMessage(exception);
            }

            RILogManager.Get(_name).Send(methodType, message, details);
        }
    }
}
