namespace Inventory.Persistence.Interfaces
{
    public interface IBaseRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddAll(IEnumerable<T> entities);
        Task<bool> UpdateAsync(int id, T entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(T TEntity);
    }
}