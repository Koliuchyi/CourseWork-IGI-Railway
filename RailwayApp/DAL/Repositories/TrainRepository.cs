using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class TrainRepository : ITrainRepository
{
    private readonly ApplicationRailwayContext _dbContext;

    public TrainRepository(ApplicationRailwayContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<Train> GetAll()
    {
        return _dbContext.Trains
            .OrderBy(c => c.Id)
            .ToList();
    }

    public Train? GetById(int id)
    {
        return _dbContext.Trains.Find(id);
    }

    public void AddEntity(Train entity)
    {
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(Train entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteEntity(int id)
    {
        Train? item = GetById(id);
        if (item != null)
            _dbContext.Trains.Remove(item);
        _dbContext.SaveChanges();
    }
}