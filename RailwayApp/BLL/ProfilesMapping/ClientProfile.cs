using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.ProfilesMapping;

public class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<Client, ClientDTO>().ReverseMap();
    }
}