using LanguageDailyTraining.Domain.Core;
using LanguageDailyTraining.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace LanguageDailyTraining.Domain.Repository
{
    public interface ITrainingPlanRepository : IRepository<TrainingPlan>
    {
        Task<TrainingPlan> GetById(Guid id);

        Task Add(TrainingPlan trainingPlan);

        void Update(TrainingPlan trainingPlan);

        void Delete(TrainingPlan trainingPlan);

        Task<Sentence> GetSentenceById(Guid sentenceId);

        Task AddSentence(Sentence sentence);

        void DeleteSentence(Sentence sentence);
    }
}
