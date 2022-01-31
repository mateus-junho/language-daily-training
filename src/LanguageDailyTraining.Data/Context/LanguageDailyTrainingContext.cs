using LanguageDailyTraining.Domain.Core;
using LanguageDailyTraining.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageDailyTraining.Data.Context
{
    public class LanguageDailyTrainingContext : DbContext, IUnitOfWork
    {
        public LanguageDailyTrainingContext(DbContextOptions<LanguageDailyTrainingContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }
        public DbSet<Sentence> Sentences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("nvarchar(200)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LanguageDailyTrainingContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
