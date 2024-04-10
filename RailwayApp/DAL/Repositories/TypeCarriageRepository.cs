using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class TypeCarriageRepository : ITypeCarriageRepository
{
    private readonly ApplicationRailwayContext _dbContext;

    public TypeCarriageRepository(ApplicationRailwayContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<TypeCarriage> GetAll()
    {
        return _dbContext.TypeCarriages
            .OrderBy(c => c.Id)
            .ToList();
    }

    public TypeCarriage? GetById(int id)
    {
        return _dbContext.TypeCarriages.Find(id);
    }

    public void AddEntity(TypeCarriage entity)
    {
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(TypeCarriage entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteEntity(int id)
    {
        TypeCarriage? item = GetById(id);
        if (item != null)
            _dbContext.TypeCarriages.Remove(item);
        _dbContext.SaveChanges();
    }
}