﻿using Management.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Management.Application.Contracts.Persistance.Repositories.Commons
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        #region Properties
        ///<summary>
        ///Gets a table
        ///</summary>
        IQueryable<T> Table { get; }

        ///<summary>
        ///Gets a table with no tracking
        ///It is used for read only operations.
        ///</summary>

        IQueryable<T> TableNoTracking { get; }
        #endregion

        #region Select
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeString = null,
            bool disableTracking = true);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<Expression<Func<T, object>>> includes = null,
            bool disableTracking = true);

        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetByIdAsync(IEnumerable<int> ids);

        Task<int> CountAsync();
        #endregion

        #region Insert
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        #endregion

        #region Update
        Task UpdateAsync(T entity);
        Task UpdateRangeAsync(IEnumerable<T> entities);
        #endregion

        #region Delete
        Task DeleteAsync(T entiy);
        Task DeleteAllAsync(IEnumerable<T> entities);

        #endregion

        #region Caching
        Task RefreshCache();
        #endregion
    }
}
