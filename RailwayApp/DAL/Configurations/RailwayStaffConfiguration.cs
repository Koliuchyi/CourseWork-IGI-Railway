using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class RailwayStaffConfiguration : IEntityTypeConfiguration<RailwayStaff>
{
    public void Configure(EntityTypeBuilder<RailwayStaff> builder)
    {
        throw new NotImplementedException();
    }
}