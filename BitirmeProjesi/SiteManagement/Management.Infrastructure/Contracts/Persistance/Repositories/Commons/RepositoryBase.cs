using Management.Application.Contracts.Persistance.Repositories.Commons;
using Management.Domain.Entities.Commons;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infrastructure.Contracts.Persistance.Repositories.Commons
{

        public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
        {
            private readonly ApplicationContext _dbContext;

            public RepositoryBase(ApplicationContext dbContext)
            {
                _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

            }
            #region Properties
            public IQueryable<T> Table
            {
                get
                {
                    return _dbContext.Set<T>();
                }
            }

            public IQueryable<T> TableNoTracking
            {
                get
                {
                    return _dbContext.Set<T>().AsNoTracking();
                }
            }

            #endregion
            #region Insert
            public async Task<T> AddAsync(T entity)
            {
                _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }

            public async Task AddRangeAsync(IEnumerable<T> entities)
            {
                _dbContext.Set<T>().AddRangeAsync(entities);
                await _dbContext.SaveChangesAsync();

            }
            #endregion

            #region Delete
            public async Task DeleteAllAsync(IEnumerable<T> entities)
            {
                _dbContext.Set<T>().RemoveRange(entities);
                await _dbContext.SaveChangesAsync();
            }

            public async Task DeleteAsync(T entiy)
            {
                _dbContext.Set<T>().Remove(entiy);
                await _dbContext.SaveChangesAsync();
            }
            #endregion
            #region Select
            public async Task<IReadOnlyList<T>> GetAllAsync()
            {
                return await _dbContext.Set<T>().ToListAsync();
            }

            public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
            {
                return await _dbContext.Set<T>().Where(predicate).ToListAsync();
            }

            public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
            {
                IQueryable<T> query = _dbContext.Set<T>();
                if (disableTracking) query = query.AsNoTracking();

                if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

                if (predicate != null) query = query.Where(predicate);

                if (orderBy != null)
                    return await orderBy(query).ToListAsync();

                return await query.ToListAsync();
            }

            public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
            {
                IQueryable<T> query = _dbContext.Set<T>();

                if (disableTracking) query = query.AsNoTracking();

                if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

                if (predicate != null) query = query.Where(predicate);

                if (orderBy != null)
                    return await orderBy(query).ToListAsync();

                return await query.ToListAsync();
            }

            public async Task<T> GetByIdAsync(int id)
            {
                return await _dbContext.Set<T>().FindAsync(id);
            }

            public async Task<IEnumerable<T>> GetByIdAsync(IEnumerable<int> ids)
            {
                return await _dbContext.Set<IEnumerable<T>>().FindAsync(ids);
            }
            public async Task<int> CountAsync()
            {
                return await _dbContext.Set<T>().CountAsync();
            }
            #endregion
            #region Caching
            public async Task RefreshCache()
            {
                var cacheList = await _dbContext.Set<T>().ToListAsync();
            }
            #endregion
            #region Update
            public async Task UpdateAsync(T entity)
            {
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
            }

            public async Task UpdateRangeAsync(IEnumerable<T> entities)
            {
                _dbContext.UpdateRange(entities);
                await _dbContext.SaveChangesAsync();
            }
            #endregion
        }
    }

