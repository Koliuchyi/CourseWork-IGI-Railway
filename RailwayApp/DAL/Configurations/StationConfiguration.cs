using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class StationConfiguration : IEntityTypeConfiguration<Station>
{
    public void Configure(EntityTypeBuilder<Station> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnName("station_id").IsRequired();
        builder.Property(s => s.Name).HasColumnName("name").HasMaxLength(30).IsRequired();
        builder.HasIndex(s => s.Name).IsUnique();
        builder
            .HasOne(s => s.City)
            .WithMany(c => c.Stations)
            .HasForeignKey(f => f.CityId);
    }
}