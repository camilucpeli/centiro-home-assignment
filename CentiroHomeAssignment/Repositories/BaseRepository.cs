using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CentiroHomeAssignment.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        public BaseRepository(CentiroHomeAssignmentContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        private CentiroHomeAssignmentContext _context { get; }
        private DbSet<T> _dbSet { get; set; }


        public virtual Task DeleteAsync(T value)
        {
            _dbSet.Remove(value);
            return _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            return await _context.FindAsync<T>(id);
        }


        public virtual async Task InsertAsync(T value)
        {
            await _dbSet.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public virtual Task UpdateAsync(T value)
        {
            _dbSet.Update(value);
            return _context.SaveChangesAsync();
        }
    }
}
