using E_Commerce.Models;

namespace E_Commerce.Repositories.IRepositories
{
    public interface IGeneric<T> where T : class
    {
        Task insertAsync(T entity);
        Task deleteAsync(int id);
        Task updateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();


    }
}
