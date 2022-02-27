using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Payment.Application.Contracts.Persistance.Repositories.Commons;
using Payment.Domain.Entities.Commons;
using Payment.Infrastructure.Contracts.Persistance.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Contracts.Persistance.Commons
{
    public class MongoRepositoryBase<T> : IMongoRepositoryBase<T> where T : EntityBase
    {
        private readonly PaymentDbContext _context;
        private readonly IMongoCollection<T> _collection;
        protected MongoRepositoryBase(IOptions<PaymentDbSettings> settings)
        {
            _context = new PaymentDbContext(settings);
            _collection = _context.GetCollection<T>();
        }
        #region Select
        public async Task<IReadOnlyList<T>> AsQueryableAsync()
        {
            return await _collection.AsQueryable().ToListAsync();

        }
        public async Task<IEnumerable<T>> FilterByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).ToListAsync();
        }
        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> FindByIdAsync(string id)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<T>.Filter.Eq("_id",objectId);
            return await _collection.Find(filter).FirstOrDefaultAsync();
            

        }
        #endregion
        #region Insert
        public async Task InsertManyAsync(IEnumerable<T> entities)
        {
            await _collection.InsertManyAsync(entities);
        }

        public async Task<T> InsertOneAsync(T entity)
        {
            var options = new InsertOneOptions { BypassDocumentValidation = false };
            await _collection.InsertOneAsync(entity, options);
            return entity; ;

        }
        #endregion
        #region Delete
        public async Task DeleteManyAsync(Expression<Func<T, bool>> predicates)
        {
            await _collection.DeleteManyAsync(predicates);
        }

        public async Task DeleteOneAsync(Expression<Func<T, bool>> predicate)
        {
            await _collection.FindOneAndDeleteAsync(predicate);

        }

        #endregion

        #region Update

        public async Task ReplaceOneAsync(T entity, string id)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<T>.Filter.Eq("_id", objectId);
            await _collection.ReplaceOneAsync(filter, entity);

        }
        #endregion
    }
}
