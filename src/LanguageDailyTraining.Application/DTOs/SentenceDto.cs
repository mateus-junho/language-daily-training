using System;
using System.ComponentModel.DataAnnotations;

namespace LanguageDailyTraining.Application.DTOs
{
    public class SentenceDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public Guid TrainingPlanId { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public string Meaning { get; set; }
    }
}
