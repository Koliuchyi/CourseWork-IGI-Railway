using DAL.Entities;

namespace DAL.Interfaces;

public interface ICarriageRepository : IRepository<Carriage>
{
    public IEnumerable<Carriage> GetAllWithCarTypes();
    public Carriage? GetByIdWithCarTypes(int id);
}