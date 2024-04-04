using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.ProfilesMapping;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<City, CityDTO>().ReverseMap();
    }
}