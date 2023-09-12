using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQLSample.API.Entities.Context;

public class VehicleContextConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Make)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);

        builder.Property(e => e.Model)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);

        builder.Property(e => e.Vin)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);

        builder.Property(e => e.TransimissionType)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);

        builder.Property(e => e.ModelYear)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);

        builder.Property(e => e.FirstRegistrationDate)
        .IsRequired()
        .IsUnicode(false);

        builder.Property(e => e.MileAge)
        .IsRequired()
        .HasMaxLength(50)
        .IsUnicode(false);

        builder.Property(e => e.Color)
        .HasMaxLength(50)
        .IsUnicode(false);
    }
}
