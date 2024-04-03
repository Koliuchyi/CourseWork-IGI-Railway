using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class RouteConfiguration : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id).HasColumnName("route_id").IsRequired();
        builder.Property(r => r.DurationTime).HasColumnName("duration_time").HasMaxLength(30).IsRequired()
            .HasConversion(
                v => v.ToString(),
                v => TimeOnly.Parse(v)
            );
        builder.Property(r => r.FullRoutePrice).HasColumnName("full_price").IsRequired();
        builder
            .HasOne(r => r.Train)
            .WithOne(t => t.Route)
            .HasForeignKey<Route>(r => r.TrainId);
    }
}