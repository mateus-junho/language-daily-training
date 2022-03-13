using LanguageDailyTraining.Data.Context;
using LanguageDailyTraining.Domain.Core;
using LanguageDailyTraining.Domain.Entities;
using LanguageDailyTraining.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace LanguageDailyTraining.Data.Repository
{
    public class TrainingPlanRepository : ITrainingPlanRepository
    {
        private readonly LanguageDailyTrainingContext context;

        public TrainingPlanRepository(LanguageDailyTrainingContext context)
        {
            this.context = context;
        }

        public IUnitOfWork unitOfWork => context;

        public async Task<TrainingPlan> GetById(Guid id)
        {
            return await context.TrainingPlans.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task Add(TrainingPlan trainingPlan)
        {
            await context.TrainingPlans.AddAsync(trainingPlan);
        }

        public void Update(TrainingPlan trainingPlan)
        {
            context.TrainingPlans.Update(trainingPlan);
        }

        public void Delete(TrainingPlan trainingPlan)
        {
            context.TrainingPlans.Remove(trainingPlan);
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
