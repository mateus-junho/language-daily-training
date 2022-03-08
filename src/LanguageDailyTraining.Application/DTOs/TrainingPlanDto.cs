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

        [Range(TrainingPlan.SENTENCE_QUANTITY_MIN, TrainingPlan.SENTENCE_QUANTITY_MAX, ErrorMessage = "The value must be between {0} and {1}")]
        [Required(ErrorMessage = "Field {0} is required")]
        public int SentenceQuantity { get; set; }

        [Range(TrainingPlan.REPETITION_QUANTITY_MIN, TrainingPlan.REPETITION_QUANTITY_MAX, ErrorMessage = "The value must be between {0} and {1}")]
        [Required(ErrorMessage = "Field {0} is required")]
        public int Repetition { get; set; }
    }
}
