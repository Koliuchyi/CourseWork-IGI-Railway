using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.ProfilesMapping;

public class NewsTableProfile : Profile
{
    public NewsTableProfile()
    {
        CreateMap<NewsTable, NewsTableDTO>().ReverseMap();
    }
}