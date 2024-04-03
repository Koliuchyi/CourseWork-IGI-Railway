namespace DAL.Interfaces;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void AddEntity(T entity);
    void UpdateEntity(T entity);
    void DeleteEntity(int id);
}