using LanguageDailyTraining.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LanguageDailyTraining.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).IsRequired();

            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(p => p.Value)
                .HasColumnName("Email");
            });

            builder.HasMany(u => u.TrainingPlans)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            builder.ToTable("Users");
        }
    }
}
