using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.ProfilesMapping;

public class RouteStopProfile : Profile
{
    public RouteStopProfile()
    {
        CreateMap<RouteStop, RouteStopDTO>().ReverseMap();
    }
}