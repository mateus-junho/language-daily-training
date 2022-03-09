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

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<TrainingPlan> GetById(Guid id)
        {
            return await context.TrainingPlans.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
