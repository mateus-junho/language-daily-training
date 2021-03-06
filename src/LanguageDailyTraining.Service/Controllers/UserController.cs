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
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteUser(Guid userId)
        {
            await userAppService.DeleteUser(userId);

            return NoContent();
        }

        /// <summary>
        /// Return logged user information
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet(@"logged-user")]
        public ActionResult<LoggedUserDto> GetLoggedUser()
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
