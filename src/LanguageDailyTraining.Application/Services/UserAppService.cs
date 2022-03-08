using LanguageDailyTraining.Application.DTOs;
using LanguageDailyTraining.Application.Interfaces;
using LanguageDailyTraining.Application.Mappings;
using LanguageDailyTraining.Domain.Entities;
using LanguageDailyTraining.Domain.Repository;
using LanguageDailyTraining.Domain.ValueObjects;
using System;
using System.Threading.Tasks;

namespace LanguageDailyTraining.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository userRepository;

        public UserAppService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserDto> GetUserById(Guid id)
        {
            var user = await userRepository.GetById(id);
            return user.ToDto();
        }

        public async Task AddUser(UserDto userDto)
        {
            var email = new Email(userDto.Email);
            var user = new User(userDto.Name, email);
            await userRepository.Add(user);
            await userRepository.unitOfWork.Commit();
        }

        public void Dispose()
        {
            userRepository?.Dispose();
        }
    }
}
