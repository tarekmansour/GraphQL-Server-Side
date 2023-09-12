using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLSample.API.Entities.Context;

public class SellerContextConfiguration : IEntityTypeConfiguration<Seller>
{
    public void Configure(EntityTypeBuilder<Seller> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);

        builder.Property(e => e.Address)
        .IsRequired()
        .HasMaxLength(250)
        .IsUnicode(false);

        builder.Property(e => e.Country)
        .HasMaxLength(50)
        .IsUnicode(false);

        builder.Property(e => e.Contact)
        .HasMaxLength(150)
        .IsUnicode(false);

        builder
        .HasMany(e => e.Vehicles)
        .WithOne(v => v.Seller)
        .HasForeignKey(v => v.SellerId)
        .IsRequired();
    }
}
