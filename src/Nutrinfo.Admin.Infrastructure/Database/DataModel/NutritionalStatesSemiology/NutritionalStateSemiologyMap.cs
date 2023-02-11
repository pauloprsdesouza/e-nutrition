using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrinfo.Admin.Domain.NutritionalStatesSemiology;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.NutritionalStatesSemiology
{
    public static class NutritionalStateSemiologyMap
    {
        public static void Configure(this EntityTypeBuilder<NutritionalStateSemiology> builder)
        {
            builder.ToTable("nutritionalStateSemiology");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.SemiologyId)
                   .ValueGeneratedNever();

            builder.Property(x => x.Description);

             builder.Property(p => p.NutritionalState)
                   .IsRequired()
                   .HasConversion(
                        v => v.ToString(),
                        v => (NutritionalStatesSemiologyEnum)Enum.Parse(typeof(NutritionalStatesSemiologyEnum), v));
        }
    }
}
