// ASP.NET.Plus
// Copyright (c) 2016 ZoneMatrix Inc.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using AspNet.Plus.Logging.ReflectInsight;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace WebApi.ReflectInsightSample
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="env">The env.</param>
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()                
                .AddJsonFile("logging.json")                
                .AddEnvironmentVariables();

            Configuration = builder.Build();            
        }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Debug;
            loggerFactory.AddReflectInsight("ReflectInsight");

            app.UseIISPlatformHandler();
            app.UseMvc();

            var logger = loggerFactory.CreateLogger<Startup>();

            var exception = new Exception("Some Exception...");
            var logValues = new Dictionary<string, object>();
            logValues["key1"] = "value1";
            logValues["key2"] = "value2";
            logValues["key3"] = new { Name = "John", Age = 100 };

            logger.LogDebug("LogDebug");
            logger.LogDebug("LogDebug", exception);
            logger.LogDebug(logValues, exception);

            logger.LogVerbose("LogVerbose");
            logger.LogVerbose("LogVerbose", exception);
            logger.LogVerbose(logValues, exception);

            logger.LogInformation("LogInformation");
            logger.LogInformation("LogInformation", exception);
            logger.LogInformation(logValues, exception);

            logger.LogWarning("LogWarning");
            logger.LogWarning("LogWarning", exception);
            logger.LogWarning(logValues, exception);

            logger.LogError("LogError");
            logger.LogError("LogError", exception);
            logger.LogError(logValues, exception);

            logger.LogCritical("LogCritical");
            logger.LogCritical("LogCritical", exception);
            logger.LogCritical(logValues, exception);
        }

        // Entry point for the application.
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
