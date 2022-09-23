using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrinfo.Admin.Domain.AsciteDegrees;

namespace Nutrinfo.Admin.Api.Infrastructure.Database.DataModel.AsciteDegrees
{
    public static class AsciteDegreeMap
    {
        public static void Configure(this EntityTypeBuilder<AsciteDegree> builder)
        {
            builder.ToTable("ascitedegree");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                        .ValueGeneratedOnAdd();

            builder.Property(p => p.Degree)
                    .HasConversion(
                        v => v.ToString(),
                        v => (AsciteDegreeEnum)Enum.Parse(typeof(AsciteDegreeEnum), v));

            builder.Property(p => p.AsciticWeight);

            builder.Property(p => p.PeripheralEdema);

            builder.HasMany(p => p.Ascites)
                   .WithOne(p => p.AsciteDegree)
                   .HasForeignKey(p => p.AsciteDegreeId);
        }
    }
}
