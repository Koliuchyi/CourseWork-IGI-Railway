using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("client_id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("name").HasMaxLength(20).IsRequired();
        builder.Property(c => c.LastName).HasColumnName("lastname").HasMaxLength(20).IsRequired();
        builder.Property(c => c.ContactNumber).HasColumnName("contact_number").HasMaxLength(30);
        builder.Property(c => c.PassportData).HasColumnName("passport_data").HasMaxLength(30).IsRequired();
        builder.HasIndex(c => c.PassportData).IsUnique();
        builder.Property(c => c.Email).HasColumnName("email").HasMaxLength(30).IsRequired();
        builder.HasIndex(с => с.Email).IsUnique();
        builder.Property(c => c.Password).HasColumnName("password").HasMaxLength(30).IsRequired();
        builder.HasIndex(c => c.Password).IsUnique();
    }
}