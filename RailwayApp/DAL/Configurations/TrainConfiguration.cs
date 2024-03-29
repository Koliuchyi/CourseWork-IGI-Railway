using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class TrainConfiguration : IEntityTypeConfiguration<Train>
{
    public void Configure(EntityTypeBuilder<Train> builder)
    {
        throw new NotImplementedException();
    }
}