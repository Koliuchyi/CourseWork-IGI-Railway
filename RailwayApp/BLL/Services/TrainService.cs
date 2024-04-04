using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public class TrainService : ITrainService
{
    IRepository<Train> Database { get; set; }
    IMapper _mapper;
    
    public TrainService(IRepository<Train> db, IMapper mapper)
    {
        Database = db;
        _mapper = mapper;
    }
    
    public IEnumerable<TrainDTO> GetAll()
    {
        return _mapper.Map<IEnumerable<Train>, List<TrainDTO>>(Database.GetAll());
    }

    public TrainDTO GetById(int id)
    {
        return _mapper.Map<Train, TrainDTO>(Database.GetById(id));
    }

    public void Add(TrainDTO entity)
    {
        Database.AddEntity(_mapper.Map<Train>(entity));
    }

    public void Update(TrainDTO entity)
    {
        Database.UpdateEntity(_mapper.Map<Train>(entity));
    }

    public void Delete(int id)
    {
        Database.DeleteEntity(id);
    }
}