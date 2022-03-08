using LanguageDailyTraining.Application.DTOs;
using System;
using System.Threading.Tasks;

namespace LanguageDailyTraining.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        Task AddUser(UserDto user);

        Task<UserDto> GetUserById(Guid id);
    }
}
