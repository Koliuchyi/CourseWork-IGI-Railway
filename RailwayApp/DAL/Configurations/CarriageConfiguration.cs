using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class CarriageConfiguration : IEntityTypeConfiguration<Carriage>
{
    public void Configure(EntityTypeBuilder<Carriage> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("carriage_id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(20).IsRequired();
        builder.HasIndex(c => c.Name).IsUnique();
        builder.Property(c => c.PlacesCount).HasColumnName("places_count").IsRequired();
        builder.HasCheckConstraint("check_positive_places_count", "places_count > 0");
        builder
            .HasOne(c => c.TypeCarriage)
            .WithOne(tc => tc.Carriage)
            .HasForeignKey<Carriage>(c => c.TypeCarriageId);
    }
}