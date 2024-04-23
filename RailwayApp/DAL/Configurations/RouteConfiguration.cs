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
        builder.Property(r => r.DurationTime).HasColumnName("duration_time").IsRequired()
            .HasColumnType("time");
        builder.Property(r => r.FullRoutePrice).HasColumnName("full_price").IsRequired();
        builder
            .HasOne(r => r.Train)
            .WithMany(t => t.Routes)
            .HasForeignKey(r => r.TrainId);
    }
}