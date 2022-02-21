using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task InsertAsync(T value);
        Task UpdateAsync(T value);
        Task DeleteAsync(T value);
    }
}
