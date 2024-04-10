using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class ClientService : IClientService
{
    IClientRepository Database { get; set; }
    IMapper _mapper;
    
    public ClientService(IClientRepository db, IMapper mapper)
    {
        Database = db;
        _mapper = mapper;
    }
    
    public IEnumerable<ClientDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<Client>, List<ClientDTO>>(Database.GetAll());
    }

    public ClientDTO GetById(int id)
    {
        return _mapper.Map<Client, ClientDTO>(Database.GetById(id));
    }

    public void Add(ClientDTO entity)
    {
        Database.AddEntity(_mapper.Map<Client>(entity));
    }

    public void Update(ClientDTO entity)
    {
        Database.UpdateEntity(_mapper.Map<Client>(entity));
    }

    public void Delete(int id)
    {
        Database.DeleteEntity(id);
    }
}