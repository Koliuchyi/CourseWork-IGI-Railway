using BLL.DTO;

namespace BLL.Interfaces;

public interface ITrainService : IService<TrainDTO>
{
    public IEnumerable<TrainDTO> GetAllWithTypes();
    public TrainDTO GetByIdWithTypes(int id);
}