using LanguageDailyTraining.Application.Interfaces;
using LanguageDailyTraining.Application.Services;
using LanguageDailyTraining.Data.Context;
using LanguageDailyTraining.Data.Repository;
using LanguageDailyTraining.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace LanguageDailyTraining.Service.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITrainingPlanRepository, TrainingPlanRepository>();
            services.AddScoped<LanguageDailyTrainingContext>();

            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<ITrainingPlanAppService, TrainingPlanAppService>();
        }
    }
}
