using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class CarriageService : ICarriageService
{
    ICarriageRepository Database { get; set; }
    IMapper _mapper;
    
    public CarriageService(ICarriageRepository db, IMapper mapper)
    {
        Database = db;
        _mapper = mapper;
    }
    
    public IEnumerable<CarriageDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<Carriage>, List<CarriageDTO>>(Database.GetAll());
    }
    public IEnumerable<CarriageDTO> GetAllWithCarTypes()
    {
        var data = Database.GetAllWithCarTypes();
        return _mapper.Map<IEnumerable<Carriage>, List<CarriageDTO>>(data);
    }

    public CarriageDTO GetById(int id)
    {
        return _mapper.Map<Carriage, CarriageDTO>(Database.GetById(id));
    }
    
    public CarriageDTO GetByIdWithCarTypes(int id)
    {
        var data = Database.GetByIdWithCarTypes(id);
        return _mapper.Map<Carriage, CarriageDTO>(data);
    }

    public void Add(CarriageDTO entity)
    {
        Database.AddEntity(_mapper.Map<Carriage>(entity));
    }

    public void Update(CarriageDTO entity)
    {
        Database.UpdateEntity(_mapper.Map<Carriage>(entity));
    }

    public void Delete(int id)
    {
        Database.DeleteEntity(id);
    }
}