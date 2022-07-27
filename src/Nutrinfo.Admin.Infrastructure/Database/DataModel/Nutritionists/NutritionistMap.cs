using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrinfo.Admin.Domain.Nutritionists;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists
{
    public static class NutritionistMap
    {
        public static void Configure(this EntityTypeBuilder<Nutritionist> nutritionist)
        {
            nutritionist.ToTable("nutritionist");

            nutritionist.HasKey(p => p.UserId);

            nutritionist.Property(p => p.UserId)
                        .ValueGeneratedNever();

            nutritionist.HasIndex(p => p.Crn)
                        .IsUnique();

            nutritionist.Property(p => p.Crn)
                        .ValueGeneratedNever();

            nutritionist.Property(p => p.Password)
                        .IsRequired();

            nutritionist.HasMany(p => p.Evaluations)
                        .WithOne(p => p.Nutritionist)
                        .HasForeignKey(p => p.NutritionistId);
        }
    }
}
