using LanguageDailyTraining.Application.DTOs;
using LanguageDailyTraining.Domain.Entities;

namespace LanguageDailyTraining.Application.Mappings
{
    public static class TrainingPlanMapping
    {
        public static TrainingPlanDto ToDto(this TrainingPlan trainingPlan)
        {
            return new TrainingPlanDto
            {
                Id = trainingPlan.Id,
                UserId = trainingPlan.UserId,
                Name = trainingPlan.Name,
                SentenceQuantity = trainingPlan.SentenceQuantity,
                Repetition = trainingPlan.Repetition,
            };
        }
    }
}
