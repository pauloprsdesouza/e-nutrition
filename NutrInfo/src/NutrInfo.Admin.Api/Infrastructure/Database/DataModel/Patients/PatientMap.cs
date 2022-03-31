using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients
{
    public static class PatientMap
    {
        public static void Configure(this EntityTypeBuilder<Patient> patient)
        {
            patient.ToTable("patient");

            patient.HasKey(p => p.Id);

            patient.Property(p => p.Id)
                        .ValueGeneratedOnAdd();

            patient.Property(p => p.Name)
                        .HasMaxLength(100)
                        .IsRequired();

            patient.Property(p => p.CreatedAt)
                        .IsRequired();

            patient.Property(p => p.UpdatedAt);
        }
    }
}
