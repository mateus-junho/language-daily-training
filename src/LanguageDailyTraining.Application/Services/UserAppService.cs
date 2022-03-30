using LanguageDailyTraining.Application.Constants;
using LanguageDailyTraining.Application.DTOs;
using LanguageDailyTraining.Application.Interfaces;
using LanguageDailyTraining.Application.Mappings;
using LanguageDailyTraining.CrossCutting.Exceptions;
using LanguageDailyTraining.Domain.Entities;
using LanguageDailyTraining.Domain.Repository;
using LanguageDailyTraining.Domain.ValueObjects;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var users = await userRepository.GetAll();
            return users.ToDto();
        }

        public async Task<UserDto> GetUserById(Guid userId)
        {
            var user = await userRepository.GetById(userId);

            if (user == null)
            {
                throw new NotFoundException(ReturnMessage.USER_NOT_FOUND);
            }

            return user.ToDto();
        }

        public async Task<UserDto> AddUser(UserDto userDto)
        {
            var email = new Email(userDto.Email);
            var user = new User(userDto.Name, email);
            await userRepository.Add(user);
            await userRepository.unitOfWork.Commit();
            return user.ToDto();
        }

        public async Task UpdateUser(UserDto userDto)
        {
            var user = await userRepository.GetById(userDto.Id);
            
            if(user == null)
            {
                throw new NotFoundException(ReturnMessage.USER_NOT_FOUND);
            }

            user.Email.SetValue(userDto.Email);
            user.SetName(userDto.Name);

            userRepository.Update(user);
            await userRepository.unitOfWork.Commit();
        }

        public async Task DeleteUser(Guid userId)
        {
            var user = await userRepository.GetById(userId);

            if (user != null)
            {
                userRepository.Delete(user);
                await userRepository.unitOfWork.Commit();
            }
        }

        public void Dispose()
        {
            userRepository?.Dispose();
        }
    }
}
