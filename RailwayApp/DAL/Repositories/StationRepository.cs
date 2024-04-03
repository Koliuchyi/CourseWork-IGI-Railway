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
        Station? item = _dbContext.Stations.FirstOrDefault(c => c.Id == id);
        if (item != null)
            return item;
        return null;
    }

    public void AddEntity(Station entity)
    {
        Station? item = _dbContext.Stations.FirstOrDefault(c => c.Name == entity.Name);
        if (item != null)
            throw new Exception("Такой объект уже есть в бд");
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(Station entity)
    {
        Station? item = _dbContext.Stations.FirstOrDefault(c => c.Name == entity.Name);
        if (item == null)
            throw new Exception("Такого объекта не существует в бд");
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