using LanguageDailyTraining.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanguageDailyTraining.Data.Mappings
{
    internal class TrainingPlanMapping : IEntityTypeConfiguration<TrainingPlan>
    {
        public void Configure(EntityTypeBuilder<TrainingPlan> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.UserId).IsRequired();
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.SentenceQuantity).IsRequired();
            builder.Property(t => t.Repetition).IsRequired();
        }
    }
}
