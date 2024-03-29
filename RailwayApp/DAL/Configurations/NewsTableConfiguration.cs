using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class NewsTableConfiguration : IEntityTypeConfiguration<NewsTable>
{
    public void Configure(EntityTypeBuilder<NewsTable> builder)
    {
        throw new NotImplementedException();
    }
}