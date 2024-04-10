using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class NewsTableRepository : INewsTableRepository
{
    private readonly ApplicationRailwayContext _dbContext;

    public NewsTableRepository(ApplicationRailwayContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<NewsTable> GetAll()
    {
        return _dbContext.NewsTables
            .OrderBy(c => c.Id)
            .ToList();
    }

    public NewsTable? GetById(int id)
    {
        return _dbContext.NewsTables.Find(id);

    }

    public void AddEntity(NewsTable entity)
    {
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(NewsTable entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteEntity(int id)
    {
        NewsTable? item = GetById(id);
        if (item != null)
            _dbContext.NewsTables.Remove(item);
        _dbContext.SaveChanges();
    }
}