using LanguageDailyTraining.Application.DTOs;
using LanguageDailyTraining.Domain.Entities;

namespace LanguageDailyTraining.Application.Mappings
{
    public static class SentenceMapping
    {
        public static SentenceDto ToDto(this Sentence sentence)
        {
            return new SentenceDto
            {
                Id = sentence.Id,
                TrainingPlanId = sentence.TrainingPlanId,
                Description = sentence.Description,
                Meaning = sentence.Meaning,
            };
        }
    }
}
