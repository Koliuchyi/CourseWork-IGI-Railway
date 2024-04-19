using BLL.DTO;

namespace BLL.Interfaces;

public interface IRouteService : IService<RouteDTO>
{
    public IEnumerable<RouteDTO> GetAllWithAnotherData();
}