using LanguageDailyTraining.Application.DTOs;
using System;
using System.Threading.Tasks;

namespace LanguageDailyTraining.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        Task<UserDto> AddUser(UserDto userDto);

        Task<UserDto> GetUserById(Guid id);

        Task UpdateUser(UserDto userDto);

        Task<UserDto> DeleteUser(Guid userId);
    }
}
