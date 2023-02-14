using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrinfo.Admin.Domain.ArmMuscleCircumferencePercentils;
using Nutrinfo.Admin.Domain.Users;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.ArmMuscleCircumferencePercentils
{
    public static class ArmMuscleCircumferencePercentilMap
    {
        public static void Configure(this EntityTypeBuilder<ArmMuscleCircumferencePercentil> builder)
        {
            builder.ToTable("armMuscleCircumferencePercentil");

            builder.HasKey(p => p.Id);

            builder.Property(x => x.StartAge);

            builder.Property(x => x.EndAge);

            builder.Property(x => x.P5);

            builder.Property(x => x.P10);

            builder.Property(x => x.P25);

            builder.Property(x => x.P50);

            builder.Property(x => x.P75);

            builder.Property(x => x.P90);

            builder.Property(x => x.P95);

            builder.Property(p => p.Gender)
                .IsRequired()
                .HasConversion(
                        v => v.ToString(),
                        v => (GenderEnum)Enum.Parse(typeof(GenderEnum), v));

            builder.Property(p => p.IsAged);
        }
    }
}
