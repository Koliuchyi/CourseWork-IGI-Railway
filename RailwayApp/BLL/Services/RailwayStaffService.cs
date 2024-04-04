using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class RailwayStaffService : IRailwayStaffService
{
    IRepository<RailwayStaff> Database { get; set; }
    IMapper _mapper;
    
    public RailwayStaffService(IRepository<RailwayStaff> db, IMapper mapper)
    {
        Database = db;
        _mapper = mapper;
    }
    
    public IEnumerable<RailwayStaffDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<RailwayStaff>, List<RailwayStaffDTO>>(Database.GetAll());
    }

    public RailwayStaffDTO GetById(int id)
    {
        return _mapper.Map<RailwayStaff, RailwayStaffDTO>(Database.GetById(id));
    }

    public void Add(RailwayStaffDTO entity)
    {
        Database.AddEntity(_mapper.Map<RailwayStaff>(entity));
    }

    public void Update(RailwayStaffDTO entity)
    {
        Database.UpdateEntity(_mapper.Map<RailwayStaff>(entity));
    }

    public void Delete(int id)
    {
        Database.DeleteEntity(id);
    }
}