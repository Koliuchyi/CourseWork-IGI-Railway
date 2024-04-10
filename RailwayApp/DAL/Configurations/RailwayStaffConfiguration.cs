using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class RailwayStaffConfiguration : IEntityTypeConfiguration<RailwayStaff>
{
    public void Configure(EntityTypeBuilder<RailwayStaff> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnName("staff_id").IsRequired();
        builder.Property(s => s.Name).HasColumnName("name").HasMaxLength(20).IsRequired();
        builder.Property(s => s.LastName).HasColumnName("lastname").HasMaxLength(20).IsRequired();
        builder.Property(s => s.Role).HasColumnName("role").HasMaxLength(20).IsRequired();
        builder.Property(s => s.ContactNumber).HasColumnName("contact_number").HasMaxLength(30).IsRequired();
        builder.Property(s => s.PassportData).HasColumnName("passport_data").HasMaxLength(30).IsRequired();
        builder.Property(s => s.Email).HasColumnName("email").HasMaxLength(35).IsRequired();
        builder.HasIndex(s => s.Email).IsUnique();
        builder.Property(s => s.Password).HasColumnName("password").HasMaxLength(30).IsRequired();
        builder.HasIndex(s => s.Password).IsUnique();
    }
}