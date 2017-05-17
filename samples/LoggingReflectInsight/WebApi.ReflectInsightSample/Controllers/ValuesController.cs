using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReflectInsight.Extensions.Logging;
using System.Collections.Generic;

namespace WebApi.ExceptionInterceptSample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly ILogger _logger;

        public ValuesController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ValuesController>();
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var result = new string[] { "value1", "value2" };

            _logger.LogJSON("Test", result);

            return result;
        }
    }
}
