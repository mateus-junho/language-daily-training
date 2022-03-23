using System.ComponentModel.DataAnnotations;

namespace LanguageDailyTraining.Application.DTOs
{
    public class RegisterUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password confirmation invalid")]
        public string ConfirmPassword { get; set; }
    }
}
