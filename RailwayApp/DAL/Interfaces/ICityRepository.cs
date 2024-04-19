using DAL.Entities;

namespace DAL.Interfaces;

public interface ICityRepository : IRepository<City>
{
    public IEnumerable<City> GetAllWithCounty();
    public City? GetByIdWithCountry(int id);
}