using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class TypeTrainService : ITypeTrainService
{
    ITypeTrainRepository Database { get; set; }
    IMapper _mapper;
    
    public TypeTrainService(ITypeTrainRepository db, IMapper mapper)
    {
        Database = db;
        _mapper = mapper;
    }
    
    public IEnumerable<TypeTrainDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<TypeTrain>, List<TypeTrainDTO>>(Database.GetAll());
    }

    public TypeTrainDTO GetById(int id)
    {
        return _mapper.Map<TypeTrain, TypeTrainDTO>(Database.GetById(id));
    }

    public void Add(TypeTrainDTO entity)
    {
        Database.AddEntity(_mapper.Map<TypeTrain>(entity));
    }

    public void Update(TypeTrainDTO entity)
    {
        Database.UpdateEntity(_mapper.Map<TypeTrain>(entity));
    }

    public void Delete(int id)
    {
        Database.DeleteEntity(id);
    }
}