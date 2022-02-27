using Payment.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Contracts.Persistance.Repositories.Commons
{
    public interface IMongoRepositoryBase<T> where T : EntityBase
    {

        #region Select
        Task<IReadOnlyList<T>> AsQueryableAsync();
        Task<IEnumerable<T>> FilterByAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindByIdAsync(string id);
        #endregion
        #region Insert
        Task<T> InsertOneAsync(T entity);
        Task InsertManyAsync(IEnumerable<T> entities);
        #endregion
        #region Update
        Task ReplaceOneAsync(T entity, string id);
        #endregion
        #region Delete
        Task DeleteOneAsync(Expression<Func<T, bool>> predicate);

        Task DeleteManyAsync(Expression<Func<T, bool>> predicates);
        #endregion
    
    }
}
