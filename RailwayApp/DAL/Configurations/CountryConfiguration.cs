using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("country_id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(30).IsRequired();
        builder.HasIndex(c => c.Name).IsUnique();
    }
}