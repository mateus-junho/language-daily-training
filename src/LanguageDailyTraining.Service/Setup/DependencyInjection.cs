using LanguageDailyTraining.Application.Interfaces;
using LanguageDailyTraining.Application.Services;
using LanguageDailyTraining.Data.Context;
using LanguageDailyTraining.Data.Repository;
using LanguageDailyTraining.Domain.Core;
using LanguageDailyTraining.Domain.Repository;
using LanguageDailyTraining.Service.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

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

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }
    }
}
