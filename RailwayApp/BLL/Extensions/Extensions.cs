using AutoMapper;
using BLL.Interfaces;
using BLL.ProfilesMapping;
using BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extensions;

public static class Extensions
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
         DAL.Extensions.Extensions.ConfigureDAL(services, configuration);
        
         IMapper mapper = new MapperConfiguration(mc =>
         {
             mc.AddProfile(new CarriageProfile());
             mc.AddProfile(new CityProfile());
             mc.AddProfile(new ClientProfile());
             mc.AddProfile(new CountryProfile());
             mc.AddProfile(new NewsTableProfile());
             mc.AddProfile(new RailwayStaffProfile());
             mc.AddProfile(new RouteProfile());
             mc.AddProfile(new RouteStopProfile());
             mc.AddProfile(new StationProfile());
             mc.AddProfile(new TicketProfile());
             mc.AddProfile(new TrainProfile());
             mc.AddProfile(new TypeCarriageProfile());
             mc.AddProfile(new TypeTrainProfile());
         }).CreateMapper();
        
        services.AddSingleton(mapper);

        services.AddScoped<ICarriageService, CarriageService>();
        services.AddScoped<ICityService, CityService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<ICountryService, CountryService>();
        services.AddScoped<INewsTableService, NewsTableService>();
        services.AddScoped<IRailwayStaffService, RailwayStaffService>();
        services.AddScoped<IRouteService, RouteService>();
        services.AddScoped<IRouteStopService, RouteStopService>();
        services.AddScoped<IStationService, StationService>();
        services.AddScoped<ITicketService, TicketService>();
        services.AddScoped<ITrainService, TrainService>();
        services.AddScoped<ITypeCarriageService, TypeCarriageService>();
        services.AddScoped<ITypeTrainService, TypeTrainService>();
    }
}