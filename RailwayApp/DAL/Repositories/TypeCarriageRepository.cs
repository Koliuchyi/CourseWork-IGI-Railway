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

    public TypeCarriage GetById(int id)
    {
        TypeCarriage? item = _dbContext.TypeCarriages.FirstOrDefault(c => c.Id == id);
        if (item != null)
            return item;
        return null;
    }

    public void AddEntity(TypeCarriage entity)
    {
        TypeCarriage? item = _dbContext.TypeCarriages.FirstOrDefault(c => c.TypeName == entity.TypeName);
        if (item != null)
            throw new Exception("Такой объект уже есть в бд");
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(TypeCarriage entity)
    {
        TypeCarriage? item = _dbContext.TypeCarriages.FirstOrDefault(c => c.TypeName == entity.TypeName);
        if (item == null)
            throw new Exception("Такого объекта не существует в бд");
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