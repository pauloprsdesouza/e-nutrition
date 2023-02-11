using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrinfo.Admin.Domain.Biochemistries;

namespace Nutrinfo.Admin.Infrastructure.Database.DataModel.Biochemistries
{
    public static class BichemistryMap
    {
        public static void Configure(this EntityTypeBuilder<Biochemistry> builder)
        {
            builder.ToTable("biochemistry");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(x => x.HealthExam);

            builder.Property(x => x.MinimumThreshold);

            builder.Property(x => x.MaximumThreshold);

            builder.Property(x => x.PossibleMeanings);
        }
    }
}
