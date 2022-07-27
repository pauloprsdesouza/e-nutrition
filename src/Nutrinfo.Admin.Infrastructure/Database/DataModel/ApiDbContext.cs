using Microsoft.EntityFrameworkCore;
using Nutrinfo.Admin.Domain.Addresses;
using Nutrinfo.Admin.Domain.Evaluations;
using Nutrinfo.Admin.Domain.Nutritionists;
using Nutrinfo.Admin.Domain.Patients;
using Nutrinfo.Admin.Domain.Users;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Addresses;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.AmputatedLimbs;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Evaluations;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Users;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.Entity<Nutritionist>().Configure();
            modelBuilder.Entity<Patient>().Configure();
            modelBuilder.Entity<User>().Configure();
            modelBuilder.Entity<Address>().Configure();
            modelBuilder.Entity<Evaluation>().Configure();
        }
    }
}

