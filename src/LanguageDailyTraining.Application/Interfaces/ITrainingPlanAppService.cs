using LanguageDailyTraining.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LanguageDailyTraining.Application.Interfaces
{
    public interface ITrainingPlanAppService : IDisposable
    {
        Task<TrainingPlanDto> GetTrainingPlanById(Guid trainingPlanId);

        Task<TrainingPlanDto> AddTrainingPlan(TrainingPlanDto trainingPlanDto);

        Task UpdateTrainingPlan(TrainingPlanDto trainingPlanDto);

        Task<TrainingPlanDto> DeleteTrainingPlan(Guid trainingPlanId);
    }
}
