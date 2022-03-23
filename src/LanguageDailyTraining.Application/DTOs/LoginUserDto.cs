using System.ComponentModel.DataAnnotations;

namespace LanguageDailyTraining.Application.DTOs
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
