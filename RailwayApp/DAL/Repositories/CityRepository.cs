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

    public City GetById(int id)
    {
        City? item = _dbContext.Cities.FirstOrDefault(c => c.Id == id);
        if (item != null)
            return item;
        return null;
    }

    public void AddEntity(City entity)
    {
        City? item = _dbContext.Cities.FirstOrDefault(c => c.Name == entity.Name);
        if (item != null)
            throw new Exception("Такой объект уже есть в бд");
        _dbContext.Add(entity);
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(City entity)
    {
        City? item = _dbContext.Cities.FirstOrDefault(c => c.Name == entity.Name);
        if (item == null)
            throw new Exception("Такого объекта не существует в бд");
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