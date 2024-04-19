using BLL.DTO;

namespace BLL.Interfaces;

public interface ICityService : IService<CityDTO>
{
    public IEnumerable<CityDTO> GetAllWithCountry();
    public CityDTO GetByIdWithCountry(int id);
}