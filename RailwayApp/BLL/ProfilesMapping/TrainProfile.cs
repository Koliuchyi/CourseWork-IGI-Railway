
using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.ProfilesMapping;

public class TrainProfile : Profile
{
    public TrainProfile()
    {
        CreateMap<Train, TrainDTO>().ReverseMap();
    }
}