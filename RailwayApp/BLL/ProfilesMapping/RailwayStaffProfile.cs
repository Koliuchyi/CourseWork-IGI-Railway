using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.ProfilesMapping;

public class RailwayStaffProfile : Profile
{
    public RailwayStaffProfile()
    {
        CreateMap<RailwayStaff, RailwayStaffDTO>().ReverseMap();
    }
}