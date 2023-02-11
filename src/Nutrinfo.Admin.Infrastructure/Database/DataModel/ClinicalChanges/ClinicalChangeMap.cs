using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrinfo.Admin.Domain.ClinicalChanges;
using Nutrinfo.Admin.Domain.Evaluations;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.ClinicalChanges
{
    public static class ClinicalChangeMap
    {
        public static void Configure(this EntityTypeBuilder<ClinicalChange> builder)
        {
            builder.ToTable("clinicalChange");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.BodyRegion);

            builder.Property(x => x.SignsAndSymptoms);

            builder.Property(x => x.PossibleMeaning);
        }
    }
}
