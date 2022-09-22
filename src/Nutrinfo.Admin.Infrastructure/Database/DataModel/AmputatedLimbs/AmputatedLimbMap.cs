using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrinfo.Admin.Domain.AmputatedLimbs;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.AmputatedLimbs
{
    public static class AmputatedLimbMap
    {
        public static void Configure(this EntityTypeBuilder<AmputatedLimb> builder)
        {
            builder.ToTable("amputatedlimb");

            builder.HasKey(p => new { p.EvaluationId, p.PatientId, p.AmputatedLimbPercentageId });

            builder.Property(p => p.EvaluationId)
                        .ValueGeneratedNever();

            builder.Property(p => p.PatientId)
                        .ValueGeneratedNever();

            builder.Property(p => p.AmputatedLimbPercentageId)
                        .ValueGeneratedNever();

            builder.HasIndex(p => p.Reason);
        }
    }
}
