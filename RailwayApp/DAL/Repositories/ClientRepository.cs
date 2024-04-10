using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationRailwayContext _dbContext;

    public ClientRepository(ApplicationRailwayContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<Client> GetAll()
    {
        return _dbContext.Clients
            .OrderBy(c => c.Id)
            .ToList();
    }

    public Client? GetById(int id)
    {
        return _dbContext.Clients.Find(id);

    }

    public void AddEntity(Client entity)
    {
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(Client entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void DeleteEntity(int id)
    {
        Client? item = GetById(id);
        if (item != null)
            _dbContext.Clients.Remove(item);
        _dbContext.SaveChanges();
    }
}