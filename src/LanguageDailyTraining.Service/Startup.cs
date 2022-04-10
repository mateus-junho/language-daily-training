using HealthChecks.UI.Client;
using LanguageDailyTraining.Data.Context;
using LanguageDailyTraining.Service.Middleware;
using LanguageDailyTraining.Service.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace LanguageDailyTraining.Service
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if(hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddDbContext<LanguageDailyTrainingContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentityConfiguration(Configuration);

            services.AddSwaggerConfiguration();

            services.RegisterServices();

            services.AddHealthChecks()
                .AddSqlServer(Configuration.GetConnectionString("DefaultConnection"), name: "SQL Database");

            services.AddControllers();

            services.AddMvc(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts(); // only https connections
            }

            app.UseExceptionMiddleware();
            app.UseHttpsRedirection(); // if http redirect to https connection

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerConfiguration(provider);

            app.UseHealthChecks("/api/healthcheck", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        }
    }
}
