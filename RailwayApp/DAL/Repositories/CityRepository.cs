using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CityRepository : ICityRepository
{
    private readonly ApplicationRailwayContext _dbContext;

    public CityRepository(ApplicationRailwayContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<City> GetAll()
    {
        return _dbContext.Cities
            .OrderBy(c => c.Id)
            .ToList();
    }

    public City? GetById(int id)
    {
        return _dbContext.Cities.Find(id);

    }

    public void AddEntity(City entity)
    {
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(City entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteEntity(int id)
    {
        City? item = GetById(id);
        if (item != null)
            _dbContext.Cities.Remove(item);
        _dbContext.SaveChanges();
    }
}