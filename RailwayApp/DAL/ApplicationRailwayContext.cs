using System.Threading.Channels;
using DAL.Configurations;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL;

public class ApplicationRailwayContext : DbContext
{
    public DbSet<Carriage> Carriages { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<NewsTable> NewsTables { get; set; } = null!;
    public DbSet<RailwayStaff> RailwayStaves { get; set; } = null!;
    public DbSet<Route> Routes { get; set; } = null!;
    public DbSet<RouteStop> RouteStops { get; set; } = null!;
    public DbSet<Station> Stations { get; set; } = null!;
    public DbSet<Ticket> Tickets { get; set; } = null!;
    public DbSet<Train> Trains { get; set; } = null!;
    public DbSet<TypeCarriage> TypeCarriages { get; set; } = null!;
    public DbSet<TypeTrain> TypeTrains { get; set; } = null!;

    public ApplicationRailwayContext()
    {
        Database.EnsureCreated();
    }

    private readonly StreamWriter logStream = new StreamWriter("mylog.txt", true);
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.LogTo(logStream.WriteLine);
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("ConnectString");
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    
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