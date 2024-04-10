using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class NewsTableService : INewsTableService
{
    INewsTableRepository Database { get; set; }
    IMapper _mapper;
    
    public NewsTableService(INewsTableRepository db, IMapper mapper)
    {
        Database = db;
        _mapper = mapper;
    }
    
    public IEnumerable<NewsTableDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<NewsTable>, List<NewsTableDTO>>(Database.GetAll());
    }

    public NewsTableDTO GetById(int id)
    {
        return _mapper.Map<NewsTable, NewsTableDTO>(Database.GetById(id));
    }

    public void Add(NewsTableDTO entity)
    {
        Database.AddEntity(_mapper.Map<NewsTable>(entity));
    }

    public void Update(NewsTableDTO entity)
    {
        Database.UpdateEntity(_mapper.Map<NewsTable>(entity));
    }

    public void Delete(int id)
    {
        Database.DeleteEntity(id);
    }
}