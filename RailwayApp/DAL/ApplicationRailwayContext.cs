using DAL.Configurations;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
namespace DAL;

public class ApplicationRailwayContext : DbContext
{
    public ApplicationRailwayContext(DbContextOptions<ApplicationRailwayContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
    public DbSet<Carriage> Carriages { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<NewsTable> NewsTables { get; set; }
    public DbSet<RailwayStaff> RailwayStaves { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<RouteStop> RouteStops { get; set; }
    public DbSet<Station> Stations { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Train> Trains { get; set; }
    public DbSet<TypeCarriage> TypeCarriages { get; set; }
    public DbSet<TypeTrain> TypeTrains { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CarriageConfiguration());
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new NewsTableConfiguration());
        modelBuilder.ApplyConfiguration(new RailwayStaffConfiguration());
        modelBuilder.ApplyConfiguration(new RouteStopConfiguration());
        modelBuilder.ApplyConfiguration(new RouteConfiguration());
        modelBuilder.ApplyConfiguration(new StationConfiguration());
        modelBuilder.ApplyConfiguration(new TicketConfiguration());
        modelBuilder.ApplyConfiguration(new TrainConfiguration());
        modelBuilder.ApplyConfiguration(new TypeCarriageConfiguration());
        modelBuilder.ApplyConfiguration(new TypeTrainConfiguration());
    }
}