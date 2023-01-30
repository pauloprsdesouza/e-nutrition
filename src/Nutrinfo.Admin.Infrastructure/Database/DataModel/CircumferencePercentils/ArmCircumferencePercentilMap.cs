using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrinfo.Admin.Domain.CircumferencePercentils;
using Nutrinfo.Admin.Domain.Users;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.CircumferencePercentils
{
    public static class ArmCircumferencePercentilMap
    {
        public static void Configure(this EntityTypeBuilder<ArmCircumferencePercentil> builder)
        {
            builder.ToTable("armCircumferencePercentil");

            builder.HasKey(p => p.Id);

            builder.Property(x => x.StartAge);

            builder.Property(x => x.EndAge);

            builder.Property(x => x.P5);

            builder.Property(x => x.P10);

            builder.Property(x => x.P15);

            builder.Property(x => x.P25);

            builder.Property(x => x.P50);

            builder.Property(x => x.P75);

            builder.Property(x => x.P85);

            builder.Property(x => x.P90);

            builder.Property(x => x.P95);

            builder.Property(p => p.Gender)
                .IsRequired()
                .HasConversion(
                        v => v.ToString(),
                        v => (GenderEnum)Enum.Parse(typeof(GenderEnum), v));

        }
    }
}
