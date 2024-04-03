using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class RouteStopConfiguration : IEntityTypeConfiguration<RouteStop>
{
    public void Configure(EntityTypeBuilder<RouteStop> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnName("route_stop_id").IsRequired();
        builder.Property(s => s.SequenceNumber).HasColumnName("sequence_number").IsRequired();
        builder.HasCheckConstraint("check_positive_sequence_number", "sequence_number > 0");

        builder.Property(s => s.DepartureDate).HasColumnName("departure_date").IsRequired()
            .HasColumnType("date")
            .HasConversion(
                v => v.ToString("dd.MM.yyyy"),
                v => DateOnly.Parse(v)
            );
        builder.Property(s => s.ArrivalDate).HasColumnName("arrival_date").IsRequired()
            .HasColumnType("date")
            .HasConversion(
                v => v.ToString("dd.MM.yyyy"),
                v => DateOnly.Parse(v)
            );
        builder.Property(s => s.DepartureTime).HasColumnName("departure_time").IsRequired()
            .HasColumnType("time")
            .HasConversion(
                v => v.ToString("HH:mm"),
                v => TimeOnly.Parse(v)
            );
        builder.Property(s => s.ArrivalTime).HasColumnName("arrival_time").IsRequired()
            .HasColumnType("time")
            .HasConversion(
                v => v.ToString("HH:mm"),
                v => TimeOnly.Parse(v)
            );
        
        builder
            .HasOne(s => s.Station)
            .WithOne(s => s.RouteStop)
            .HasForeignKey<RouteStop>(f => f.StationId);
        builder
            .HasOne(s => s.Route)
            .WithMany(r => r.RouteStops)
            .HasForeignKey(f => f.RouteId);
    }
}