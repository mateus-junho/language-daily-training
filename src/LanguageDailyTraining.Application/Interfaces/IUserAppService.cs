using LanguageDailyTraining.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LanguageDailyTraining.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        Task<IEnumerable<UserDto>> GetUsers();

        Task<UserDto> GetUserById(Guid userId);

        Task<UserDto> AddUser(UserDto userDto);

        Task UpdateUser(UserDto userDto);

        Task<UserDto> DeleteUser(Guid userId);
    }
}
