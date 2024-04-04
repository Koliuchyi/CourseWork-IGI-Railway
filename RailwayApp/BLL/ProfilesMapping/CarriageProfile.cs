using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.ProfilesMapping;

public class CarriageProfile : Profile
{
    public CarriageProfile()
    {
        CreateMap<Carriage, CarriageDTO>().ReverseMap();
    }    
}