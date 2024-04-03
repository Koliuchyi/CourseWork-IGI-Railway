using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("city_id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(30).IsRequired();
        builder.HasIndex(c => c.Name).IsUnique();
        builder.Property(c => c.EngName).HasColumnName("eng_name").HasMaxLength(30).IsRequired();
        builder.Property(c => c.Description).HasColumnName("description").IsRequired();
        builder.Property(c => c.Photo).HasColumnName("photo").IsRequired();
        builder
            .HasOne(c => c.Country)
            .WithMany(c => c.Cities)
            .HasForeignKey(f => f.CountryId);
    }
}