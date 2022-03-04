using LanguageDailyTraining.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanguageDailyTraining.Data.Mappings
{
    public class SentenceMapping : IEntityTypeConfiguration<Sentence>
    {
        public void Configure(EntityTypeBuilder<Sentence> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.TrainingPlanId).IsRequired();
            builder.Property(s => s.Description).IsRequired();
            builder.Property(s => s.Meaning).IsRequired().HasColumnType("nvarchar(500)");
            builder.Property(s => s.Hits).IsRequired();
            builder.Property(s => s.Errors).IsRequired();
            builder.Property(s => s.Active).IsRequired();
            builder.Property(s => s.LastTimeCheck).IsRequired();
            builder.Property(s => s.RegisterDate).IsRequired();

            builder.HasOne(s => s.TrainingPlan)
                .WithMany(t => t.Sentences)
                .HasForeignKey(s => s.TrainingPlanId);
        }
    }
}
