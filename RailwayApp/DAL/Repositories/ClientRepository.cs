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

    public Client GetById(int id)
    {
        Client? item = _dbContext.Clients.FirstOrDefault(c => c.Id == id);
        if (item != null)
            return item;
        return null;
    }

    public void AddEntity(Client entity)
    {
        Client? item = _dbContext.Clients.FirstOrDefault(c => c.PassportData == entity.PassportData);
        if (item != null)
            throw new Exception("Такой объект уже есть в бд");
        _dbContext.Add(entity); 
        _dbContext.SaveChanges();
    }

    public void UpdateEntity(Client entity)
    {
        Client? item = _dbContext.Clients.FirstOrDefault(c => c.PassportData == entity.PassportData);
        if (item == null)
            throw new Exception("Такого объекта не существует в бд");
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