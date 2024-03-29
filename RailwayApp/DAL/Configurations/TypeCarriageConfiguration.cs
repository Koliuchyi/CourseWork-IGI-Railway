using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class TypeCarriageConfiguration : IEntityTypeConfiguration<TypeCarriage>
{
    public void Configure(EntityTypeBuilder<TypeCarriage> builder)
    {
        throw new NotImplementedException();
    }
}