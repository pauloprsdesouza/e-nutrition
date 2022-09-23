using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrinfo.Admin.Domain.Ascites;

namespace Nutrinfo.Admin.Api.Infrastructure.Database.DataModel.Ascites
{
    public static class AsciteMap
    {
        public static void Configure(this EntityTypeBuilder<Ascite> builder)
        {
            builder.ToTable("ascite");

            builder.HasKey(p => new { p.AsciteDegreeId, p.EvaluationId });

            builder.Property(p => p.AsciteDegreeId)
                        .ValueGeneratedNever();

            builder.Property(p => p.EvaluationId)
                        .ValueGeneratedNever();

            builder.Property(p => p.HasAsciticWeight);

            builder.Property(p => p.HasPeripheralEdema);

            builder.Property(p => p.Reason);
        }
    }
}
