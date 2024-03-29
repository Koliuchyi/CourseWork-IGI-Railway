using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class CarriageConfiguration : IEntityTypeConfiguration<Carriage>
{
    public void Configure(EntityTypeBuilder<Carriage> builder)
    {
        throw new NotImplementedException();
    }
}