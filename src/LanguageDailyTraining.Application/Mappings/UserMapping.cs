using LanguageDailyTraining.Application.DTOs;
using LanguageDailyTraining.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LanguageDailyTraining.Application.Mappings
{
    public static class UserMapping
    {
        public static UserDto ToDto(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email.Value,
            };
        }

        public static IEnumerable<UserDto> ToDto(this IEnumerable<User> users)
        {
            if(users == null || !users.Any())
            {
                return new List<UserDto>();
            }

            return users.Select(u => ToDto(u));
        }
    }
}
