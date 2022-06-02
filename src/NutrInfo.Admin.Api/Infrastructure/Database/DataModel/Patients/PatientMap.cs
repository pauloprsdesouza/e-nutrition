using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients
{
    public static class PatientMap
    {
        public static void Configure(this EntityTypeBuilder<Patient> patient)
        {
            patient.ToTable("patient");

            patient.HasKey(p => p.UserId);

            patient.Property(p => p.UserId)
                   .ValueGeneratedOnAdd();

            patient.Property(p => p.Race)
                   .IsRequired();

            patient.HasMany(p => p.Evaluations)
                   .WithOne(p => p.Patient)
                   .HasForeignKey(p => p.PatientId);
        }
    }
}
