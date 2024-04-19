using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class TypeTrainConfiguration : IEntityTypeConfiguration<TypeTrain>
{
    public void Configure(EntityTypeBuilder<TypeTrain> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("type_train_id").IsRequired();
        builder.Property(t => t.TypeName).HasColumnName("type_name").HasMaxLength(20).IsRequired();
        builder.HasIndex(t => t.TypeName).IsUnique();
        builder.Property(t => t.Description).HasColumnName("description").IsRequired();
        builder.Property(t => t.Photo).HasColumnName("photo").IsRequired();
    }
}