using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.ProfilesMapping;

public class StationProfile : Profile
{
    public StationProfile()
    {
        CreateMap<Station, StationDTO>().ReverseMap();
    }
}