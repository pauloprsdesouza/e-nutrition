using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrinfo.Admin.Domain.SignsAndSymptoms;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.SignsAndSymptoms
{
    public static class SignAndSymptomMap
    {
        public static void Configure(this EntityTypeBuilder<SignAndSymptom> builder)
        {
            builder.ToTable("signAndSymptom");

            builder.HasKey(p => p.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.ClinicalChangeId)
                   .ValueGeneratedNever();

            builder.Property(x => x.PossibleMeanings);

            builder.Property(x => x.Description);
        }
    }
}
