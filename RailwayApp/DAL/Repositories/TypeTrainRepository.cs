using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class TypeTrainRepository : ITypeTrainRepository
{
    private readonly ApplicationRailwayContext _dbContext;

    public TypeTrainRepository(ApplicationRailwayContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<TypeTrain> GetAll()
    {
        return _dbContext.TypeTrains
            .OrderBy(c => c.Id)
            .ToList();
    }

    public TypeTrain? GetById(int id)
    {
        return _dbContext.TypeTrains.Find(id);
    }

    public void AddEntity(TypeTrain entity)
    {
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(TypeTrain entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteEntity(int id)
    {
        TypeTrain? item = GetById(id);
        if (item != null)
            _dbContext.TypeTrains.Remove(item);
        _dbContext.SaveChanges();
    }
}