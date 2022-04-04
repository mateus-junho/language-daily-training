using Microsoft.AspNetCore.Mvc;

namespace LanguageDailyTraining.Service.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/test-version")]
    [ApiController]
    public class TestVersionController : ControllerBase
    {
        [HttpGet]
        public string GetVersion()
        {
            return "version 2.0";
        }
    }
}
