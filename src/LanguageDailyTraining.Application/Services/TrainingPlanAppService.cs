using LanguageDailyTraining.Application.DTOs;
using LanguageDailyTraining.Application.Interfaces;
using LanguageDailyTraining.Application.Mappings;
using LanguageDailyTraining.CrossCutting.Exceptions;
using LanguageDailyTraining.Domain.Entities;
using LanguageDailyTraining.Domain.Repository;
using System;
using System.Threading.Tasks;

namespace LanguageDailyTraining.Application.Services
{
    public class TrainingPlanAppService : ITrainingPlanAppService
    {
        private readonly ITrainingPlanRepository trainingPlanRepository;

        public TrainingPlanAppService(ITrainingPlanRepository trainingPlanRepository)
        {
            this.trainingPlanRepository = trainingPlanRepository;
        }

        public async Task<TrainingPlanDto> GetTrainingPlanById(Guid trainingPlanId)
        {
            var trainingPlan = await trainingPlanRepository.GetById(trainingPlanId);
            return trainingPlan.ToDto();
        }

        public async Task<TrainingPlanDto> AddTrainingPlan(TrainingPlanDto trainingPlanDto)
        {
            var trainingPlan = new TrainingPlan(trainingPlanDto.UserId, trainingPlanDto.Name, trainingPlanDto.SentenceQuantity, trainingPlanDto.Repetition);
            await trainingPlanRepository.Add(trainingPlan);
            await trainingPlanRepository.unitOfWork.Commit();
            return trainingPlan.ToDto();
        }

        public async Task UpdateTrainingPlan(TrainingPlanDto trainingPlanDto)
        {
            var trainingPlan = await trainingPlanRepository.GetById(trainingPlanDto.Id);

            if (trainingPlan == null)
            {
                throw new NotFoundException();
            }

            trainingPlan.SetName(trainingPlanDto.Name);
            trainingPlan.SetSentenceQuantity(trainingPlanDto.SentenceQuantity);
            trainingPlan.SetRepetition(trainingPlanDto.Repetition);

            trainingPlanRepository.Update(trainingPlan);
            await trainingPlanRepository.unitOfWork.Commit();
        }

        public async Task<TrainingPlanDto> DeleteTrainingPlan(Guid trainingPlanId)
        {
            var trainingPlan = await trainingPlanRepository.GetById(trainingPlanId);

            if (trainingPlan == null)
            {
                throw new NotFoundException();
            }

            trainingPlanRepository.Delete(trainingPlan);
            await trainingPlanRepository.unitOfWork.Commit();

            return trainingPlan.ToDto();
        }

        public void Dispose()
        {
            trainingPlanRepository?.Dispose();
        }
    }
}
