using LanguageDailyTraining.Application.Constants;
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
        private readonly IUserRepository userRepository;

        public TrainingPlanAppService(ITrainingPlanRepository trainingPlanRepository, IUserRepository userRepository)
        {
            this.trainingPlanRepository = trainingPlanRepository;
            this.userRepository = userRepository;
        }

        public async Task<TrainingPlanDto> GetTrainingPlanById(Guid trainingPlanId)
        {
            var trainingPlan = await trainingPlanRepository.GetById(trainingPlanId);
            return trainingPlan.ToDto();
        }

        public async Task<TrainingPlanDto> AddTrainingPlan(TrainingPlanDto trainingPlanDto)
        {
            var user = await userRepository.GetById(trainingPlanDto.UserId);

            if (user == null)
            {
                throw new ArgumentException(ReturnMessage.USER_NOT_FOUND);
            }

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
                throw new NotFoundException(ReturnMessage.TRAINING_PLAN_NOT_FOUND);
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
                throw new NotFoundException(ReturnMessage.TRAINING_PLAN_NOT_FOUND);
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
