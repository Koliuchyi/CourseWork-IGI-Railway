using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CarriageRepository : ICarriageRepository
{
    private readonly ApplicationRailwayContext _dbContext;

    public CarriageRepository(ApplicationRailwayContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<Carriage> GetAll()
    {
        return _dbContext.Carriages
            .OrderBy(c => c.Id)
            .ToList();
    }

    public Carriage? GetById(int id)
    {
        Carriage? carriage = _dbContext.Carriages.FirstOrDefault(c => c.Id == id);
        if (carriage != null)
            return carriage;
        return null;
    }

    public void AddEntity(Carriage entity)
    {
        Carriage? carriage = _dbContext.Carriages.FirstOrDefault(c => c.Name == entity.Name);
        if (carriage != null)
            throw new Exception("Такой объект уже есть в бд");
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(Carriage entity)
    {
        Carriage? carriage = _dbContext.Carriages.FirstOrDefault(c => c.Name == entity.Name);
        if (carriage == null)
            throw new Exception("Такого объекта не существует в бд");
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteEntity(int id)
    {
        Carriage? item = GetById(id);
        if (item != null)
            _dbContext.Carriages.Remove(item);
        _dbContext.SaveChanges();
    }
}