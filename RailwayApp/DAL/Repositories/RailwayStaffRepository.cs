using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class RailwayStaffRepository : IRailwayStaffRepository
{
    private readonly ApplicationRailwayContext _dbContext;

    public RailwayStaffRepository(ApplicationRailwayContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<RailwayStaff> GetAll()
    {
        return _dbContext.RailwayStaves
            .OrderBy(c => c.Id)
            .ToList();
    }

    public RailwayStaff GetById(int id)
    {
        RailwayStaff? item = _dbContext.RailwayStaves.FirstOrDefault(c => c.Id == id);
        if (item != null)
            return item;
        return null;
    }

    public void AddEntity(RailwayStaff entity)
    {
        RailwayStaff? item = _dbContext.RailwayStaves.FirstOrDefault(c => c.PassportData == entity.PassportData);
        if (item != null)
            throw new Exception("Такой объект уже есть в бд");
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(RailwayStaff entity)
    {
        RailwayStaff? item = _dbContext.RailwayStaves.FirstOrDefault(c => c.PassportData == entity.PassportData);
        if (item == null)
            throw new Exception("Такого объекта не существует в бд");
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteEntity(int id)
    {
        RailwayStaff? item = GetById(id);
        if (item != null)
            _dbContext.RailwayStaves.Remove(item);
        _dbContext.SaveChanges();
    }
}