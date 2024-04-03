using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly ApplicationRailwayContext _dbContext;

    public CountryRepository(ApplicationRailwayContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<Country> GetAll()
    {
        return _dbContext.Countries
            .OrderBy(c => c.Id)
            .ToList();
    }

    public Country GetById(int id)
    {
        Country? item = _dbContext.Countries.FirstOrDefault(c => c.Id == id);
        if (item != null)
            return item;
        return null;
    }

    public void AddEntity(Country entity)
    {
        Country? item = _dbContext.Countries.FirstOrDefault(c => c.Name == entity.Name);
        if (item != null)
            throw new Exception("Такой объект уже есть в бд");
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(Country entity)
    {
        Country? item = _dbContext.Countries.FirstOrDefault(c => c.Name == entity.Name);
        if (item == null)
            throw new Exception("Такого объекта не существует в бд");
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteEntity(int id)
    {
        Country? item = GetById(id);
        if (item != null)
            _dbContext.Countries.Remove(item);
        _dbContext.SaveChanges();
    }
}