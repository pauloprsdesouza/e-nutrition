using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrinfo.Admin.Domain.Limbs;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.Limbs
{
    public static class AmputatedLimbMap
    {
        public static void Configure(this EntityTypeBuilder<Limb> builder)
        {
            builder.ToTable("limb");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                        .ValueGeneratedOnAdd();

            builder.HasIndex(p => p.Name);

            builder.Property(p => p.Percentil);


        }
    }
}
