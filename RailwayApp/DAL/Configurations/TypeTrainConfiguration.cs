using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class TypeTrainConfiguration : IEntityTypeConfiguration<TypeTrain>
{
    public void Configure(EntityTypeBuilder<TypeTrain> builder)
    {
        throw new NotImplementedException();
    }
}