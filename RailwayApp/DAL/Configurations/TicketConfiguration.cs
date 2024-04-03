using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("ticket_id").IsRequired();
        builder.Property(t => t.SeatNumber).HasColumnName("seat_number").IsRequired();
        builder.Property(t => t.TicketPrice).HasColumnName("price").IsRequired();
        builder
            .HasOne(t => t.Route)
            .WithMany(r => r.Tickets)
            .HasForeignKey(t => t.RouteId);
        builder
            .HasOne(t => t.Client)
            .WithMany(c => c.Tickets)
            .HasForeignKey(t => t.ClientId);
    }
}