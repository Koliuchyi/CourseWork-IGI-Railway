using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class TrainConfiguration : IEntityTypeConfiguration<Train>
{
    public void Configure(EntityTypeBuilder<Train> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("train_id").IsRequired();
        builder.Property(t => t.Name).HasColumnName("name").HasMaxLength(20).IsRequired();
        builder.HasIndex(t => t.Name).IsUnique();
        builder.Property(t => t.CarriageCount).HasColumnName("carriage_count").IsRequired();
        builder.HasCheckConstraint("check_positive_carriage_count", "carriage_count > 0");
        builder
            .HasOne(t => t.TypeTrain)
            .WithOne(tt => tt.Train)
            .HasForeignKey<Train>(t => t.TypeTrainId);
    }
}