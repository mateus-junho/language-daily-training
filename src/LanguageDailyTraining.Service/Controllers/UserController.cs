using LanguageDailyTraining.Application.DTOs;
using LanguageDailyTraining.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LanguageDailyTraining.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService userAppService;

        public UserController(IUserAppService userAppService)
        {
            this.userAppService = userAppService;
        }

        [HttpGet(@"{userId}")]
        public async Task<ActionResult<UserDto>> GetUser(Guid userId)
        {
            var user = await userAppService.GetUserById(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut(@"{userId}")]
        public async Task<ActionResult> UpdateUser(Guid userId, UserDto user)
        {
            if (userId != user.Id)
            {
                return BadRequest();
            }

            await userAppService.UpdateUser(user);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> UpdateUser(UserDto user)
        {
            var savedUser = await userAppService.AddUser(user);

            return CreatedAtAction(nameof(GetUser), new { userId = savedUser.Id }, savedUser);
        }

        [HttpDelete(@"{userId}")]
        public async Task<ActionResult<UserDto>> DeleteUser(Guid userId)
        {
            var deletedUser = await userAppService.DeleteUser(userId);

            return Ok(deletedUser);
        }
    }
}
