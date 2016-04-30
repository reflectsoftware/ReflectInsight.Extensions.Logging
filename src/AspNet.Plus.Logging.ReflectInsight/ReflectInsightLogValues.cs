// ASP.NET.Plus
// Copyright (c) 2016 ZoneMatrix Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace AspNet.Plus.Logging.ReflectInsight
{
    public class ReflectInsightLogValues : ILogValues
    {
        private static string _className;

        private readonly IEnumerable<KeyValuePair<string, object>> _values;
        private readonly string _message;

        /// <summary>
        /// Initializes the <see cref="ReflectInsightLogValues"/> class.
        /// </summary>
        static ReflectInsightLogValues()
        {
            _className = typeof(ReflectInsightLogValues).FullName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyLogValues" /> class.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="message">The message.</param>
        public ReflectInsightLogValues(IEnumerable<KeyValuePair<string, object>> values, string message = null)
        {            
            _values = values;
            _message = message ?? _className;
        }

        /// <summary>
        /// Returns an enumerable of key value pairs mapping the name of the structured data to the data.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, object>> GetValues()
        {
            return _values;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return _message;
        }
    }
}
