//using AspNet.Plus.Logging.ReflectInsight;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Console.ReflectInsightSample
{
    public class Program
    {
        private static LoggerFactory _factory;
        private static IConfigurationRoot _loggingConfiguration;

        public static void Main(string[] args)
        {            
            _loggingConfiguration = new ConfigurationBuilder()
                //.AddXmlFile("ReflectInsight.config")
                .Build();

            //_factory = new LoggerFactory();
            //_factory.AddReflectInsight();

            //var logger = _factory.CreateLogger<Program>();

            //logger.LogDebug("Debug");
            //logger.LogWarning("Warning");
        }
    }
}
