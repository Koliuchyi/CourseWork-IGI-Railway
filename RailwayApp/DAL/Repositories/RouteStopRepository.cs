using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class RouteStopRepository : IRouteStopRepository
{
    private readonly ApplicationRailwayContext _dbContext;

    public RouteStopRepository(ApplicationRailwayContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<RouteStop> GetAll()
    {
        return _dbContext.RouteStops
            .OrderBy(c => c.Id)
            .ToList();
    }

    public RouteStop GetById(int id)
    {
        RouteStop? item = _dbContext.RouteStops.FirstOrDefault(c => c.Id == id);
        if (item != null)
            return item;
        return null;
    }

    public void AddEntity(RouteStop entity)
    {
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(RouteStop entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteEntity(int id)
    {
        RouteStop? item = GetById(id);
        if (item != null)
            _dbContext.RouteStops.Remove(item);
        _dbContext.SaveChanges();
    }
}