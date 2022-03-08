using LanguageDailyTraining.Application.DTOs;
using LanguageDailyTraining.Domain.Entities;

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
    }
}
