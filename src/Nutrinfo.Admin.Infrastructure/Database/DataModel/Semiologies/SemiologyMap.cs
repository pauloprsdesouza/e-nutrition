using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrinfo.Admin.Domain.Semiologies;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.Semiologies
{
    public static class SemiologyMap
    {
        public static void Configure(this EntityTypeBuilder<Semiology> builder)
        {
            builder.ToTable("semiology");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Group)
                   .IsRequired()
                   .HasConversion(
                        v => v.ToString(),
                        v => (SemiologyGroupEnum)Enum.Parse(typeof(SemiologyGroupEnum), v));

            builder.Property(p => p.Hint);

            builder.Property(p => p.BodyRegion);

            builder.HasMany(x => x.NutritionalStates)
                   .WithOne(x => x.Semiology)
                   .HasForeignKey(x => x.SemiologyId);
        }
    }
}
