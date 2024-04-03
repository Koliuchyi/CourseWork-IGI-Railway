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

    public Train GetById(int id)
    {
        Train? item = _dbContext.Trains.FirstOrDefault(c => c.Id == id);
        if (item != null)
            return item;
        return null;
    }

    public void AddEntity(Train entity)
    {
        Train? item = _dbContext.Trains.FirstOrDefault(c => c.Name == entity.Name);
        if (item != null)
            throw new Exception("Такой объект уже есть в бд");
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(Train entity)
    {
        Train? item = _dbContext.Trains.FirstOrDefault(c => c.Name == entity.Name);
        if (item == null)
            throw new Exception("Такого объекта не существует в бд");
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