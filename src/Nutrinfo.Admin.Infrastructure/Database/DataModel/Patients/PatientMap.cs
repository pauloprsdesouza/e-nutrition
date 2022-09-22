using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrinfo.Admin.Domain.Patients;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients
{
    public static class PatientMap
    {
        public static void Configure(this EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("patient");

            builder.HasKey(p => p.UserId);

            builder.Property(p => p.UserId)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.Race)
                   .IsRequired();

            builder.HasMany(p => p.Evaluations)
                   .WithOne(p => p.Patient)
                   .HasForeignKey(p => p.PatientId);

            builder.HasMany(p => p.AmputatedLimbs)
                   .WithOne(p => p.Patient)
                   .HasForeignKey(p => p.PatientId);
        }
    }
}
