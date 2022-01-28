using Microsoft.EntityFrameworkCore;
using Movies.Application.Contract.Repository;
using Movies.Domain.Common;
using Movies.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Contracts.Repository.Common
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
    {
        protected readonly MovieContext _movieContext;
        public RepositoryBase(MovieContext movieContext)
        {
            _movieContext = movieContext ?? throw new ArgumentNullException(nameof(movieContext));
        }
        public async Task<T> AddAsync(T entity)
        {
            _movieContext.Set<T>().Add(entity);
            await _movieContext.SaveChangesAsync();  
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _movieContext.Set<T>().Remove(entity);
            await _movieContext.SaveChangesAsync();
            return entity;
            
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _movieContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _movieContext.Set<T>().Where(predicate).ToListAsync(); 
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<T> query = _movieContext.Set<T>();
            if (disableTracking) query = query.Include(includeString);

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if(predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();

        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = _movieContext.Set<T>();
            if (disableTracking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if(predicate != null) query= query.Where(predicate);
            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _movieContext.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _movieContext.Entry(entity).State = EntityState.Modified;
            await _movieContext.SaveChangesAsync();
            return entity;
        }
    }
}
