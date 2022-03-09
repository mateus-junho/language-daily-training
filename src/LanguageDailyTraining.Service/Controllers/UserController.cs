using LanguageDailyTraining.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LanguageDailyTraining.Service.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService userAppService;

        public UserController(IUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        [HttpGet(@"user/{userId}")]
        public async Task<IActionResult> GetUser(Guid userId)
        {
            var user = await userAppService.GetUserById(userId);
            return Ok(user);
        }
    }
}
