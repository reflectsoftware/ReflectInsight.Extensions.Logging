using AspNet.Plus.Logging.ReflectInsight;
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

        public static void Main(string[] args)
        {
            _factory = new LoggerFactory();            
            _factory.AddReflectInsight();

            var xxx = ReflectSoftware.Insight.RIListenerGroupManager.Add("");
            xxx.AddDestination("", "details", true, new ReflectSoftware.Insight.FilterInfo("", ReflectSoftware.Insight.FilterMode.Include) {
            });
                       
            // ReflectSoftware.Insight.ReflectInsightConfig.Settings.

            var logger = _factory.CreateLogger<Program>();

            logger.LogDebug("Debug");
            logger.LogWarning("Warning");

            System.Console.WriteLine("Pres any key to terminate...");
            System.Console.ReadKey();            
        }
    }
}
