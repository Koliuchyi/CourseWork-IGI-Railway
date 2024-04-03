using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class TicketRepository : ITicketRepository
{
    private readonly ApplicationRailwayContext _dbContext;

    public TicketRepository(ApplicationRailwayContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<Ticket> GetAll()
    {
        return _dbContext.Tickets
            .OrderBy(c => c.Id)
            .ToList();    }

    public Ticket GetById(int id)
    {
        Ticket? item = _dbContext.Tickets.FirstOrDefault(c => c.Id == id);
        if (item != null)
            return item;
        return null;
    }

    public void AddEntity(Ticket entity)
    {
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(Ticket entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteEntity(int id)
    {
        Ticket? item = GetById(id);
        if (item != null)
            _dbContext.Tickets.Remove(item);
        _dbContext.SaveChanges();
    }
}