using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LanguageDailyTraining.Service.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/test-version")]
    [ApiController]
    public class TestVersionController : ControllerBase
    {
        private readonly ILogger logger;

        public TestVersionController(ILogger<TestVersionController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public string GetVersion()
        {
            logger.LogTrace("Trace log"); // don't display
            logger.LogDebug("Debug log");
            logger.LogInformation("Information log");
            logger.LogWarning("Warning log");
            logger.LogError("Error log");
            logger.LogCritical("Critical error log");

            return "version 2.0";
        }
    }
}
