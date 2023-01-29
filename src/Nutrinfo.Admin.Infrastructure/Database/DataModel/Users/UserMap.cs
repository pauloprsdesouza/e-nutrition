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
        public static void Configure(this EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.HasIndex(p => p.Cpf)
                .IsUnique();

            builder.Property(p => p.Cpf)
                .IsRequired();

            builder.Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(200)
                .IsRequired(false);

            builder.HasIndex(p => p.Email)
                .IsUnique();

            builder.Property(p => p.BirthDate)
                   .IsRequired();

            builder.Property(p => p.Gender)
                .IsRequired()
                .HasConversion(
                        v => v.ToString(),
                        v => (GenderEnum)Enum.Parse(typeof(GenderEnum), v));

            builder.Property(p => p.Status)
                .IsRequired()
                .HasConversion(
                        v => v.ToString(),
                        v => (UserStatusEnum)Enum.Parse(typeof(UserStatusEnum), v));

            builder.Property(p => p.CreatedAt)
                .IsRequired();

            builder.Property(p => p.UpdatedAt);

            builder.HasOne(p => p.Nutritionist)
                .WithOne(p => p.User)
                .HasForeignKey<Nutritionist>(p => p.UserId);

            builder.HasOne(p => p.Patient)
                .WithOne(p => p.User)
                .HasForeignKey<Patient>(p => p.UserId);

            builder.HasOne(p => p.Address)
                .WithOne(p => p.User)
                .HasForeignKey<Address>(p => p.UserId);
        }
    }
}
