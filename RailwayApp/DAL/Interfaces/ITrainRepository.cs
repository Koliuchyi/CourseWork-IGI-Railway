using DAL.Entities;

namespace DAL.Interfaces;

public interface ITrainRepository : IRepository<Train>
{
    public IEnumerable<Train> GetAllWithTypes();
    public Train? GetByIdWithTypes(int id);
}