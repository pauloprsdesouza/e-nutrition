using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.AmputatedLimbs
{
    public static class AamputatedLimbMap
    {
        public static void Configure(this EntityTypeBuilder<AmputatedLimb> amputatedLimb)
        {
            amputatedLimb.ToTable("amputatedlimb");

            amputatedLimb.HasKey(p => p.Id);

            amputatedLimb.Property(p => p.Id)
                         .ValueGeneratedOnAdd();

            amputatedLimb.Property(p => p.Limb);

            amputatedLimb.Property(p => p.Percentual);

            amputatedLimb.HasMany(p => p.Evaluations)
                         .WithMany(p => p.AmputatedLimbs)
                         .UsingEntity("amputatedlimbs");
        }
    }
}
