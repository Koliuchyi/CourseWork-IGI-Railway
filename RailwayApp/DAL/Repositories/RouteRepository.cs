using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class RouteRepository : IRouteRepository
{
    private readonly ApplicationRailwayContext _dbContext;

    public RouteRepository(ApplicationRailwayContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<Route> GetAll()
    {
        return _dbContext.Routes
            .OrderBy(c => c.Id)
            .ToList();
    }

    public Route GetById(int id)
    {
        Route? item = _dbContext.Routes.FirstOrDefault(c => c.Id == id);
        if (item != null)
            return item;
        return null;
    }

    public void AddEntity(Route entity)
    {
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(Route entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteEntity(int id)
    {
        Route? item = GetById(id);
        if (item != null)
            _dbContext.Routes.Remove(item);
        _dbContext.SaveChanges();
    }
}