using BLL.DTO;

namespace BLL.Interfaces;

public interface ICarriageService : IService<CarriageDTO>
{
    public IEnumerable<CarriageDTO> GetAllWithCarTypes();
    public CarriageDTO GetByIdWithCarTypes(int id);
}