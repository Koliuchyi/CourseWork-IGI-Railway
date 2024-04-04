using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class RouteStopService : IRouteStopService
{
    IRepository<RouteStop> Database { get; set; }
    IMapper _mapper;
    
    public RouteStopService(IRepository<RouteStop> db, IMapper mapper)
    {
        Database = db;
        _mapper = mapper;
    }
    
    public IEnumerable<RouteStopDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<RouteStop>, List<RouteStopDTO>>(Database.GetAll());
    }

    public RouteStopDTO GetById(int id)
    {
        return _mapper.Map<RouteStop, RouteStopDTO>(Database.GetById(id));
    }

    public void Add(RouteStopDTO entity)
    {
        Database.AddEntity(_mapper.Map<RouteStop>(entity));
    }

    public void Update(RouteStopDTO entity)
    {
        Database.UpdateEntity(_mapper.Map<RouteStop>(entity));
    }

    public void Delete(int id)
    {
        Database.DeleteEntity(id);
    }
}