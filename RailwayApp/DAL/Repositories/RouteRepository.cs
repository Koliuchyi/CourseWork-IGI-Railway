using System.Collections;
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

    public IEnumerable<Route> GetAllWithAnotherData()
    {
        return _dbContext.Routes
            .Include(t => t.Train)
            .ThenInclude(tt => tt.TypeTrain)
            .Include(t => t.Train)
            .ThenInclude(c => c.Carriage)
            .ThenInclude(tc => tc.TypeCarriage)
            .Include(rt => rt.RouteStops)
            .ThenInclude(s => s.Station)
            .ThenInclude(c => c.City)
            .ThenInclude(ct => ct.Country)
            .Include(tc => tc.Tickets)
            .ThenInclude(cl => cl.Client)
            .OrderBy(r => r.Id)
            .ToList();
    }

    public Route? GetById(int id)
    {
        return _dbContext.Routes.Find(id);
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