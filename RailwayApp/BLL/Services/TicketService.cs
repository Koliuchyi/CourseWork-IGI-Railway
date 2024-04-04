using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class TicketService : ITicketService
{
    IRepository<Ticket> Database { get; set; }
    IMapper _mapper;
    
    public TicketService(IRepository<Ticket> db, IMapper mapper)
    {
        Database = db;
        _mapper = mapper;
    }
    
    public IEnumerable<TicketDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<Ticket>, List<TicketDTO>>(Database.GetAll());
    }

    public TicketDTO GetById(int id)
    {
        return _mapper.Map<Ticket, TicketDTO>(Database.GetById(id));
    }

    public void Add(TicketDTO entity)
    {
        Database.AddEntity(_mapper.Map<Ticket>(entity));
    }

    public void Update(TicketDTO entity)
    {
        Database.UpdateEntity(_mapper.Map<Ticket>(entity));
    }

    public void Delete(int id)
    {
        Database.DeleteEntity(id);
    }
}