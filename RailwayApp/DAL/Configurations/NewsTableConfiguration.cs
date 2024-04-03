using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class NewsTableConfiguration : IEntityTypeConfiguration<NewsTable>
{
    public void Configure(EntityTypeBuilder<NewsTable> builder)
    {
        builder.HasKey(n => n.Id);
        builder.Property(n => n.Id).HasColumnName("news_table_id").IsRequired();
        builder.Property(n => n.Description).HasColumnName("description").IsRequired();
        builder.Property(n => n.Title).HasColumnName("title").HasMaxLength(20).IsRequired();
        builder.Property(n => n.Photo).HasColumnName("photo").IsRequired();
    }
}