// ReflectInsight
// Copyright (c) 2017 ReflectSoftware.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information. 

using ReflectInsight.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

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
            var builder = new ConfigurationBuilder()
                          .SetBasePath(env.ContentRootPath)
                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
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
        /// <param name="loggerFactory">The logger factory.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {            
            loggerFactory.AddReflectInsight("ReflectInsight.config");
            
            app.UseMvc();

            var exception = new Exception("Some exception");
            var logger = loggerFactory.CreateLogger<Startup>();

            using (logger.BeginScope("Hello: {0}, {1}", 5, 6))
            {
                logger.LogWarning("LogWarning with some args: {0}, {2}", 1, 2);
            }

            logger.LogDebug("LogDebug");
            logger.LogTrace("LogTrace");
            
            logger.LogInformation("LogInformation");
            logger.LogInformation(exception, "LogInformation with exception");
            logger.LogInformation(exception);
            
            logger.LogWarning("LogWarning");
            logger.LogWarning(exception, "LogWarning with exception");
            logger.LogWarning(exception);
            
            logger.LogError("LogError");
            logger.LogError(exception, "LogError with exception");
            logger.LogError(exception);
            
            logger.LogCritical("LogCritical");
            logger.LogCritical(exception, "LogCritical with exception");
            logger.LogCritical(exception);

            logger.LogJSON("Test", new System.Collections.Generic.List<int> { 1, 2, 3 });
            logger.LogLoadedProcesses();
            logger.LogLoadedAssemblies();
        }
    }
}
