using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.ProfilesMapping;

public class RouteProfile : Profile
{
    public RouteProfile()
    {
        CreateMap<Route, RouteDTO>().ReverseMap();
    }
}