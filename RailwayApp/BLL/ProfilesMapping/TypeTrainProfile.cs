using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.ProfilesMapping;

public class TypeTrainProfile : Profile
{
    public TypeTrainProfile()
    {
        CreateMap<TypeTrain, TypeTrainDTO>().ReverseMap();
    }
}