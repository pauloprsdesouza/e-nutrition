using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrinfo.Admin.Domain.Evaluations;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations
{
    public static class EvaluationMap
    {
        public static void Configure(this EntityTypeBuilder<Evaluation> builder)
        {
            builder.ToTable("evaluation");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                      .ValueGeneratedOnAdd();

            builder.Property(p => p.NutritionistId)
                      .ValueGeneratedNever();

            builder.Property(p => p.PatientId)
                      .ValueGeneratedNever();

            builder.Property(p => p.Weight);

            builder.Property(p => p.Height);

            builder.Property(p => p.Imc);

            builder.Property(p => p.IsWalking);

            builder.Property(p => p.HasAscite);

            builder.Property(p => p.NutritionalState);

            builder.Property(p => p.DiseaseSeverity);

            builder.Property(p => p.Status)
                    .HasConversion(
                        v => v.ToString(),
                        v => (EvaluationStatusEnum)Enum.Parse(typeof(EvaluationStatusEnum), v));

            builder.Property(p => p.CreatedAt)
                   .IsRequired();

            builder.Property(p => p.UpdatedAt);
        }
    }
}
