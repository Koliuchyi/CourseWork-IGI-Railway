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

    public RailwayStaff? GetById(int id)
    {
        return _dbContext.RailwayStaves.Find(id);
    }

    public void AddEntity(RailwayStaff entity)
    {
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(RailwayStaff entity)
    {
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