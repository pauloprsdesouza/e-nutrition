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

            builder.Property(p => p.LostWeightLastThreeMonths);

            builder.Property(p => p.ReducedDietaryIntake);

            builder.Property(p => p.SeriouslyIllPatient);

            builder.Property(p => p.NutritionalState)
                   .HasConversion(
                        v => v.ToString(),
                        v => (NutritionalStateEnum)Enum.Parse(typeof(NutritionalStateEnum), v));

            builder.Property(p => p.DiseaseSeverity)
                   .HasConversion(
                        v => v.ToString(),
                        v => (DiseaseSeverityEnum)Enum.Parse(typeof(DiseaseSeverityEnum), v));

            builder.Property(p => p.Step)
                    .HasConversion(
                        v => v.ToString(),
                        v => (EvaluationStepsEnum)Enum.Parse(typeof(EvaluationStepsEnum), v));

            builder.Property(p => p.Status)
                    .HasConversion(
                        v => v.ToString(),
                        v => (EvaluationStatusEnum)Enum.Parse(typeof(EvaluationStatusEnum), v));

            builder.Property(p => p.CreatedAt)
                   .IsRequired();

            builder.Property(p => p.UpdatedAt)
                   .IsRequired(false);

            builder.HasMany(p => p.AmputatedLimbs)
                   .WithOne(p => p.Evaluation)
                   .HasForeignKey(p => p.EvaluationId);
        }
    }
}
