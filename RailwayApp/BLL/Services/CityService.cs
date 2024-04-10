using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class CityService : ICityService
{
    ICityRepository Database { get; set; }
    IMapper _mapper;
    
    public CityService(ICityRepository db, IMapper mapper)
    {
        Database = db;
        _mapper = mapper;
    }
    
    public IEnumerable<CityDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<City>, List<CityDTO>>(Database.GetAll());
    }

    public CityDTO GetById(int id)
    {
        return _mapper.Map<City, CityDTO>(Database.GetById(id));
    }

    public void Add(CityDTO entity)
    {
        Database.AddEntity(_mapper.Map<City>(entity));
    }

    public void Update(CityDTO entity)
    {
        Database.UpdateEntity(_mapper.Map<City>(entity));
    }

    public void Delete(int id)
    {
        Database.DeleteEntity(id);
    }
}