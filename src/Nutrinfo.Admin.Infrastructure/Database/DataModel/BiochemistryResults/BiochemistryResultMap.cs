using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrinfo.Admin.Domain.BiochemistryResults;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.BiochemistryResults
{
    public static class BiochemistryResultMap
    {
        public static void Configure(this EntityTypeBuilder<BiochemistryResult> builder)
        {
            builder.ToTable("biochemistryResult");

            builder.HasKey(x => new { x.BiochemistryId, x.EvaluationId });

            builder.Property(x => x.BiochemistryId)
                   .ValueGeneratedNever();

            builder.Property(x => x.EvaluationId)
                   .ValueGeneratedNever();

            builder.Property(x => x.Result);
        }
    }
}
