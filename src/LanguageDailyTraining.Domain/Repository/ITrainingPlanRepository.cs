using LanguageDailyTraining.Domain.Core;
using LanguageDailyTraining.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace LanguageDailyTraining.Domain.Repository
{
    public interface ITrainingPlanRepository : IRepository<TrainingPlan>
    {
        Task<TrainingPlan> GetById(Guid id);
    }
}
