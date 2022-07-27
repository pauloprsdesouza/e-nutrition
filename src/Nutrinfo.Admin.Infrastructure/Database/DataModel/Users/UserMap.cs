using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrinfo.Admin.Domain.Addresses;
using Nutrinfo.Admin.Domain.Nutritionists;
using Nutrinfo.Admin.Domain.Patients;
using Nutrinfo.Admin.Domain.Users;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Users
{
    public static class UserMap
    {
        public static void Configure(this EntityTypeBuilder<User> user)
        {
            user.ToTable("user");

            user.HasKey(p => p.Id);

            user.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            user.HasIndex(p => p.Cpf)
                .IsUnique();

            user.Property(p => p.Cpf)
                .IsRequired();

            user.Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();

            user.Property(p => p.Email)
                .HasMaxLength(200)
                .IsRequired();

            user.Property(p => p.Status)
                .IsRequired();

            user.Property(p => p.CreatedAt)
                .IsRequired();

            user.Property(p => p.UpdatedAt);

            user.HasOne(p => p.Nutritionist)
                .WithOne(p => p.User)
                .HasForeignKey<Nutritionist>(p => p.UserId);

            user.HasOne(p => p.Patient)
                .WithOne(p => p.User)
                .HasForeignKey<Patient>(p => p.UserId);

             user.HasOne(p => p.Address)
                 .WithOne(p => p.User)
                 .HasForeignKey<Address>(p => p.UserId);
        }
    }
}
