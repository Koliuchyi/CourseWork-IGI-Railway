using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class StationRepository : IStationRepository
{
    private readonly ApplicationRailwayContext _dbContext;

    public StationRepository(ApplicationRailwayContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<Station> GetAll()
    {
        return _dbContext.Stations
            .OrderBy(c => c.Id)
            .ToList();
    }

    public Station GetById(int id)
    {
        return _dbContext.Stations.Find(id);
    }

    public void AddEntity(Station entity)
    {
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(Station entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteEntity(int id)
    {
        Station? item = GetById(id);
        if (item != null)
            _dbContext.Stations.Remove(item);
        _dbContext.SaveChanges();
    }
}