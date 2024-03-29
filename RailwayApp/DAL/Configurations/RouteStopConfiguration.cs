using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations;

public class RouteStopConfiguration : IEntityTypeConfiguration<RouteStop>
{
    public void Configure(EntityTypeBuilder<RouteStop> builder)
    {
        throw new NotImplementedException();
    }
}