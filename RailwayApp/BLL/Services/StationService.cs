using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class StationService : IStationService
{
    IRepository<Station> Database { get; set; }
    IMapper _mapper;
    
    public StationService(IRepository<Station> db, IMapper mapper)
    {
        Database = db;
        _mapper = mapper;
    }
    
    public IEnumerable<StationDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<Station>, List<StationDTO>>(Database.GetAll());
    }

    public StationDTO GetById(int id)
    {
        return _mapper.Map<Station, StationDTO>(Database.GetById(id));
    }

    public void Add(StationDTO entity)
    {
        Database.AddEntity(_mapper.Map<Station>(entity));
    }

    public void Update(StationDTO entity)
    {
        Database.UpdateEntity(_mapper.Map<Station>(entity));
    }

    public void Delete(int id)
    {
        Database.DeleteEntity(id);
    }
}