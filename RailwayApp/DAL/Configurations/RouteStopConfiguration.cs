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
            .HasColumnType("date");
        builder.Property(s => s.ArrivalDate).HasColumnName("arrival_date").IsRequired()
            .HasColumnType("date");
        builder.Property(s => s.DepartureTime).HasColumnName("departure_time").IsRequired()
            .HasColumnType("time");
        builder.Property(s => s.ArrivalTime).HasColumnName("arrival_time").IsRequired()
            .HasColumnType("time");
        builder
            .HasOne(s => s.Route)
            .WithMany(r => r.RouteStops)
            .HasForeignKey(f => f.RouteId);
        builder
            .HasOne(s => s.Station)
            .WithMany(st => st.RouteStops)
            .HasForeignKey(s => s.StationId);
    }
}