using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrinfo.Admin.Domain.AmputatedLimbsPercentage;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.AmputatedLimbsPercentage
{
    public static class AmputatedLimbPercentageMap
    {
        public static void Configure(this EntityTypeBuilder<AmputatedLimbPercentage> builder)
        {
            builder.ToTable("amputatedlimbpercentage");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                        .ValueGeneratedOnAdd();

            builder.Property(p => p.Name);

            builder.Property(p => p.Percentage);

            builder.HasMany(p => p.AmputatedLimbs)
                   .WithOne(p => p.LimbPercentage)
                   .HasForeignKey(p => p.AmputatedLimbPercentageId);
        }
    }
}
