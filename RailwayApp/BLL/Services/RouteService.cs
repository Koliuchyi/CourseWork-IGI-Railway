using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class RouteService : IRouteService
{
    IRouteRepository Database { get; set; }
    IMapper _mapper;
    
    public RouteService(IRouteRepository db, IMapper mapper)
    {
        Database = db;
        _mapper = mapper;
    }
    
    public IEnumerable<RouteDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<Route>, List<RouteDTO>>(Database.GetAll());
    }

    public RouteDTO GetById(int id)
    {
        return _mapper.Map<Route, RouteDTO>(Database.GetById(id));
    }

    public void Add(RouteDTO entity)
    {
        Database.AddEntity(_mapper.Map<Route>(entity));
    }

    public void Update(RouteDTO entity)
    {
        Database.UpdateEntity(_mapper.Map<Route>(entity));
    }

    public void Delete(int id)
    {
        Database.DeleteEntity(id);
    }
}