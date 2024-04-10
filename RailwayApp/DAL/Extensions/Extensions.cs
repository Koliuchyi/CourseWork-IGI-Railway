using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extensions;

public static class Extensions
{
    public static void ConfigureDAL(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationRailwayContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
         services.AddScoped<ICarriageRepository, CarriageRepository>();
         services.AddScoped<ICityRepository, CityRepository>();
         services.AddScoped<IClientRepository, ClientRepository>();
         services.AddScoped<ICountryRepository, CountryRepository>();
         services.AddScoped<INewsTableRepository, NewsTableRepository>();
         services.AddScoped<IRailwayStaffRepository, RailwayStaffRepository>();
         services.AddScoped<IRouteRepository, RouteRepository>();
         services.AddScoped<IRouteStopRepository, RouteStopRepository>();
         services.AddScoped<IStationRepository, StationRepository>();
         services.AddScoped<ITicketRepository, TicketRepository>();
         services.AddScoped<ITrainRepository, TrainRepository>();
         services.AddScoped<ITypeCarriageRepository, TypeCarriageRepository>();
         services.AddScoped<ITypeTrainRepository, TypeTrainRepository>();
    }
}