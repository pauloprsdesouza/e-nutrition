using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.Addresses;
using Nutrinfo.Admin.Domain.AmputatedLimbs;
using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.Nutritionists;
using Nutrinfo.Admin.Domain.Patients;
using Nutrinfo.Admin.Domain.Users;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Addresses;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Users;
using Nutrinfo.Admin.Api.Infrastructure.Database.DataModel.Ascites;
using Nutrinfo.Admin.Api.Infrastructure.Database.DataModel.AsciteDegrees;
using Nutrinfo.Admin.Infrastructure.Database.DataModel.AmputatedLimbs;
using Nutrinfo.Admin.Domain.AmputatedLimbsPercentage;
using Nutrinfo.Admin.Infrastructure.Database.DataModel.AmputatedLimbsPercentage;
using Nutrinfo.Admin.Infrastructure.Database.DataModel.CircumferencePercentils;
using Nutrinfo.Admin.Infrastructure.Database.DataModel.BiochemistryResults;
using Nutrinfo.Admin.Infrastructure.Database.DataModel.SignsAndSymptoms;
using Nutrinfo.Admin.Infrastructure.Database.DataModel.Semiologies;
using Nutrinfo.Admin.Infrastructure.Database.DataModel.NutritionalStatesSemiology;
using Nutrinfo.Admin.Infrastructure.Database.DataModel.ClinicalChanges;
using Nutrinfo.Admin.Domain.AsciteDegrees;
using Nutrinfo.Admin.Domain.Ascites;
using Nutrinfo.Admin.Domain.CircumferencePercentils;
using Nutrinfo.Admin.Domain.ClinicalChanges;
using Nutrinfo.Admin.Domain.Semiologies;
using Nutrinfo.Admin.Domain.NutritionalStatesSemiology;
using Nutrinfo.Admin.Domain.SignsAndSymptoms;
using Nutrinfo.Admin.Domain.BiochemistryResults;
using Nutrinfo.Admin.Domain.ArmMuscleCircumferencePercentils;
using Nutrinfo.Admin.Infrastructure.Database.DataModel.ArmMuscleCircumferencePercentils;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel
{
    public class ApiDbContext : DbContext
    {
        public const string Schema = "nutrinfo";

        public ApiDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Nutritionist> Nutritionists { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<AmputatedLimb> AmputatedLimbs { get; set; }
        public DbSet<AmputatedLimbPercentage> AmputatedLimbsPercentage { get; set; }
        public DbSet<Ascite> Ascites { get; set; }
        public DbSet<AsciteDegree> AsciteDegrees { get; set; }
        public DbSet<ArmCircumferencePercentil> ArmCircunferences { get; set; }
        public DbSet<ClinicalChange> ClinicalChanges { get; set; }
        public DbSet<Semiology> Semiologies { get; set; }
        public DbSet<NutritionalStateSemiology> NutritionalStatesSemiology { get; set; }
        public DbSet<SignAndSymptom> SignsAndSymptoms { get; set; }
        public DbSet<BiochemistryResult> BiochemistryResults { get; set; }
        public DbSet<ArmMuscleCircumferencePercentil> ArmMuscleCircunferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.Entity<Nutritionist>().Configure();
            modelBuilder.Entity<Patient>().Configure();
            modelBuilder.Entity<User>().Configure();
            modelBuilder.Entity<Address>().Configure();
            modelBuilder.Entity<Evaluation>().Configure();
            modelBuilder.Entity<AmputatedLimb>().Configure();
            modelBuilder.Entity<AmputatedLimbPercentage>().Configure();
            modelBuilder.Entity<Ascite>().Configure();
            modelBuilder.Entity<AsciteDegree>().Configure();
            modelBuilder.Entity<ArmCircumferencePercentil>().Configure();
            modelBuilder.Entity<ClinicalChange>().Configure();
            modelBuilder.Entity<Semiology>().Configure();
            modelBuilder.Entity<NutritionalStateSemiology>().Configure();
            modelBuilder.Entity<SignAndSymptom>().Configure();
            modelBuilder.Entity<BiochemistryResult>().Configure();
            modelBuilder.Entity<ArmMuscleCircumferencePercentil>().Configure();
        }
    }
}

