using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations
{
    public static class EvaluationMap
    {
        public static void Configure(this EntityTypeBuilder<Evaluation> evaluation)
        {
            evaluation.ToTable("evaluation");

            evaluation.HasKey(p => p.Id);

            evaluation.Property(p => p.Id)
                      .ValueGeneratedOnAdd();

            evaluation.Property(p => p.NutritionistId)
                      .ValueGeneratedNever();

            evaluation.Property(p => p.PatientId)
                      .ValueGeneratedNever();

            evaluation.Property(p => p.BedNumber);

            evaluation.Property(p => p.Protein);

            evaluation.Property(p => p.Energy);

            evaluation.Property(p => p.Weight);

            evaluation.Property(p => p.Height);

            evaluation.Property(p => p.Imc);

            evaluation.Property(p => p.IsWalking);

            evaluation.Property(p => p.HasEdema);

            evaluation.Property(p => p.HasEdema);

            evaluation.Property(p => p.HasAscite);

            evaluation.Property(p => p.HasAmputatedLimb);

            evaluation.Property(p => p.NutritionState);

            evaluation.Property(p => p.DiseaseSeverity);

            evaluation.Property(p => p.CreatedAt)
                      .IsRequired();

            evaluation.Property(p => p.UpdatedAt);

        }
    }
}
