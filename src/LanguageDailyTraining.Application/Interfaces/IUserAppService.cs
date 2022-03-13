using LanguageDailyTraining.Application.DTOs;
using System;
using System.Threading.Tasks;

namespace LanguageDailyTraining.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        Task<UserDto> GetUserById(Guid userId);

        Task<UserDto> AddUser(UserDto userDto);

        Task UpdateUser(UserDto userDto);

        Task<UserDto> DeleteUser(Guid userId);
    }
}
