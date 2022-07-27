using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nutrinfo.Admin.Domain.Addresses;

namespace NutrInfo.Admin.Api.Infrastructure.Database.DataModel.Addresses
{
    public static class AddressMap
    {
        public static void Configure(this EntityTypeBuilder<Address> address)
        {
            address.ToTable("address");

            address.HasKey(p => p.UserId);

            address.Property(p => p.UserId)
                   .ValueGeneratedNever();

            address.Property(p => p.Street)
                   .HasMaxLength(200)
                   .IsRequired();

            address.Property(p => p.City)
                   .HasMaxLength(100)
                   .IsRequired();

            address.Property(p => p.State)
                    .HasMaxLength(100)
                    .IsRequired();

            address.Property(p => p.Neighborhood)
                    .HasMaxLength(100)
                    .IsRequired();

            address.Property(p => p.Number)
                   .IsRequired();

            address.Property(p => p.Complement)
                    .HasMaxLength(100);

            address.Property(p => p.ZipCode);
        }
    }
}
