using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApp.Models;

namespace MovieApp.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id, bool isActive = true);
        Task InsertAsync(T entity, bool saveChange = true);
        Task UpdateAsync(T entity, bool saveChange = true);
        Task DeleteAsync(T entity, bool saveChange = true);
    }
}