using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class TypeCarriageService : ITypeCarriageService
{
    IRepository<TypeCarriage> Database { get; set; }
    IMapper _mapper;
    
    public TypeCarriageService(IRepository<TypeCarriage> db, IMapper mapper)
    {
        Database = db;
        _mapper = mapper;
    }
    
    public IEnumerable<TypeCarriageDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<TypeCarriage>, List<TypeCarriageDTO>>(Database.GetAll());
    }

    public TypeCarriageDTO GetById(int id)
    {
        return _mapper.Map<TypeCarriage, TypeCarriageDTO>(Database.GetById(id));
    }

    public void Add(TypeCarriageDTO entity)
    {
        Database.AddEntity(_mapper.Map<TypeCarriage>(entity));
    }

    public void Update(TypeCarriageDTO entity)
    {
        Database.UpdateEntity(_mapper.Map<TypeCarriage>(entity));
    }

    public void Delete(int id)
    {
        Database.DeleteEntity(id);
    }
}