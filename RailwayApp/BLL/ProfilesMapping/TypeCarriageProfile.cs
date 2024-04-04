using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.ProfilesMapping;

public class TypeCarriageProfile : Profile
{
    public TypeCarriageProfile()
    {
        CreateMap<TypeCarriage, TypeCarriageDTO>().ReverseMap();
    }
}