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
        return _dbContext.Carriages.Find(id);
    }

    public void AddEntity(Carriage entity)
    {
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }
    
    public void UpdateEntity(Carriage entity)
    {
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