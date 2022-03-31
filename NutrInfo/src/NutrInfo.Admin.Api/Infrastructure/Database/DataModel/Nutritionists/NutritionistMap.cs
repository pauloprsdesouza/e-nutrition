using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists
{
    public static class NutritionistMap
    {
        public static void Configure(this EntityTypeBuilder<Nutritionist> nutritionist)
        {
            nutritionist.ToTable("nutritionist");

            nutritionist.HasKey(p => p.Crn);

            nutritionist.Property(p => p.Crn)
                        .ValueGeneratedNever();

            nutritionist.Property(p => p.Name)
                        .HasMaxLength(200)
                        .IsRequired();

            nutritionist.Property(p => p.Email)
                        .HasMaxLength(200)
                        .IsRequired();

            nutritionist.Property(p => p.Status)
                        .IsRequired();

            nutritionist.Property(p => p.Password)
                        .IsRequired();

            nutritionist.Property(p => p.CreatedAt)
                        .IsRequired();

            nutritionist.Property(p => p.UpdatedAt);
        }
    }
}
