using LanguageDailyTraining.Application.DTOs;
using LanguageDailyTraining.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using LanguageDailyTraining.Service.Extensions;
using LanguageDailyTraining.Domain.Core;

namespace LanguageDailyTraining.Service.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService userAppService;
        private readonly IUser appUser;

        public UserController(IUserAppService userAppService, IUser appUser)
        {
            this.userAppService = userAppService;
            this.appUser = appUser;
        }

        [ClaimsAuthorize("Administrator", "Manager")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var user = await userAppService.GetUsers();
            return Ok(user);
        }

        [HttpGet(@"{userId}")]
        public async Task<ActionResult<UserDto>> GetUser(Guid userId)
        {
            var user = await userAppService.GetUserById(userId);

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<UserDto>> AddUser(UserDto user)
        {
            var savedUser = await userAppService.AddUser(user);

            return CreatedAtAction(nameof(GetUser), new { userId = savedUser.Id }, savedUser);
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

        [HttpDelete(@"{userId}")]
        public async Task<ActionResult<UserDto>> DeleteUser(Guid userId)
        {
            var deletedUser = await userAppService.DeleteUser(userId);

            return Ok(deletedUser);
        }

        /// <summary>
        /// Return logged user information
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet(@"logged-user")]
        public ActionResult<LoggedUserDto> GetLoggedUser(Guid userId)
        {
            var loggedUser = new LoggedUserDto
            {
                UserId = appUser.GetUserId(),
                Email = appUser.GetUserEmail(),
            };

            return Ok(loggedUser);
        }
    }
}
