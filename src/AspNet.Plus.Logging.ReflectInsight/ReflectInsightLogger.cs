// ASP.NET.Plus
// Copyright (c) 2016 ASP.NET Plus.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Microsoft.Extensions.Logging;
using ReflectSoftware.Insight;
using ReflectSoftware.Insight.Common;
using RI.Utils.ExceptionManagement;
using System;
using System.Collections.Specialized;

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
        /// <typeparam name="TState">The type of the state.</typeparam>
        /// <param name="state">The identifier for the scope.</param>
        /// <returns>
        /// An IDisposable that ends the logical operation scope on dispose.
        /// </returns>
        public IDisposable BeginScope<TState>(TState state)
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
        /// <typeparam name="TState">The type of the state.</typeparam>
        /// <param name="logLevel">The log level.</param>
        /// <param name="eventId">The event identifier.</param>
        /// <param name="state">The state.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="formatter">The formatter.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
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

            var messageType = MessageType.Clear;
            switch (logLevel)
            {
                case LogLevel.Debug:
                    messageType = MessageType.SendDebug;
                    break;

                case LogLevel.Trace:
                    messageType = MessageType.SendTrace;
                    break;

                case LogLevel.Information:
                    messageType = MessageType.SendInformation;
                    break;

                case LogLevel.Warning:
                    messageType = MessageType.SendWarning;
                    break;

                case LogLevel.Error:
                    messageType = MessageType.SendError;
                    break;

                case LogLevel.Critical:
                    messageType = MessageType.SendFatal;
                    break;
            }

            var details = (string)null;
            if (exception != null)
            {
                var additional = (NameValueCollection)null;
                if(eventId.Id > 0)
                {
                    additional = new NameValueCollection();
                    additional["eventName"] = eventId.Name ?? messageType.ToString();
                    additional["eventId"] = eventId.Id.ToString();
                }
                
                details = ExceptionBasePublisher.ConstructIndentedMessage(exception, additional);
            }

            RILogManager.Get(_name).Send(messageType, message, details);
        }
    }
}
