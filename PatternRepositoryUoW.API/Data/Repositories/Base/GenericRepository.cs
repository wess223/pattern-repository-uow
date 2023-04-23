using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace PatternRepositoryUoW.API.Data.Repositories.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSete;
        public GenericRepository(ApplicationContext context)
        {
            _dbSete = context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSete.Add(entity);
        }
        public void Remove(T entity)
        {
            _dbSete.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSete.Update(entity);
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSete.CountAsync(expression);
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSete.FirstOrDefaultAsync(expression);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSete.FindAsync(id);
        }

        public async Task<List<T>> GetDataAsync(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            int? skip = null,
            int? take = null)
        {
            var query = _dbSete.AsQueryable();

            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (include != null)
            {
                query = include(query);
            }
            if (skip != null && skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }
            if (take != null && take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return await query.ToListAsync();
        }
    }
}
