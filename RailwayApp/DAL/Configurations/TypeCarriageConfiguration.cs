using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class TypeCarriageConfiguration : IEntityTypeConfiguration<TypeCarriage>
{
    public void Configure(EntityTypeBuilder<TypeCarriage> builder)
    {
        builder.HasKey(tc => tc.Id);
        builder.Property(tc => tc.Id).HasColumnName("type_carriage_id").IsRequired();
        builder.Property(tc => tc.TypeName).HasColumnName("type_name").HasMaxLength(20).IsRequired();
        builder.HasIndex(tc => tc.TypeName).IsUnique();
        builder.Property(tc => tc.Photo).HasColumnName("photo").IsRequired();
    }
}