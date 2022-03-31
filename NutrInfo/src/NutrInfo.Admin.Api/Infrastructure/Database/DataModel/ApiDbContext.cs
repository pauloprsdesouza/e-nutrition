using Microsoft.EntityFrameworkCore;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Nutritionists;
using NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Patients;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel
{
    public class ApiDbContext : DbContext
    {
        public const string Schema = "nutrinfo";

        public ApiDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Nutritionist> Nutritionists { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.Entity<Nutritionist>().Configure();
            modelBuilder.Entity<Patient>().Configure();
        }
    }
}
