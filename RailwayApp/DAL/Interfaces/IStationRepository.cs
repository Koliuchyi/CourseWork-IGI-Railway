using DAL.Entities;

namespace DAL.Interfaces;

public interface IStationRepository : IRepository<Station>
{
    public IEnumerable<Station> GetAllWithCity();
    public Station? GetByIdWithCity(int id);
}