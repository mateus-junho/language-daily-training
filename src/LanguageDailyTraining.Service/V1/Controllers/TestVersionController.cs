using Microsoft.AspNetCore.Mvc;

namespace LanguageDailyTraining.Service.V1.Controllers
{
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/test-version")]
    [ApiController]
    public class TestVersionController : ControllerBase
    {
        [HttpGet]
        public string GetVersion()
        {
            return "version 1.0";
        }
    }
}
