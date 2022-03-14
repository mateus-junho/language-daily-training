using LanguageDailyTraining.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace LanguageDailyTraining.Application.DTOs
{
    public class TrainingPlanDto
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public int SentenceQuantity { get; set; }

        [Required(ErrorMessage = "Field {0} is required")]
        public int Repetition { get; set; }
    }
}
