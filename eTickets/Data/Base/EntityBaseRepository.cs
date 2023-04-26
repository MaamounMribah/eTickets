using System.Linq.Expressions;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T> :IEntityBaseRepository<T> where T : class, IEntityBase,new()
    {
        private readonly AppDbContext appDbcontext;

        public EntityBaseRepository(AppDbContext context)
        {
            appDbcontext = context;
        }
        public async Task AddAsync(T entity)
        {
            await appDbcontext.Set<T>().AddAsync(entity);
            await appDbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await appDbcontext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                appDbcontext.Set<T>().Remove(entity);
                await appDbcontext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await appDbcontext.Set<T>().ToListAsync();
            return result;
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = appDbcontext.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();

        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await appDbcontext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = appDbcontext.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.FirstOrDefaultAsync(n => n.Id == id);
        }
        public async Task<T> UpdateAsync(int id, T entity)
        {
            appDbcontext.Set<T>().Update(entity);
            await appDbcontext.SaveChangesAsync();
            return entity;
        }

    }
}
