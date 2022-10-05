using Billing.Authentication.Infrastructure.Data;
using Billing.Authentication.Infrastructure.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Billing.Authentication.Infrastructure.Repositories
{
    public abstract class BaseRepositoryAsync<TEntity> 
        : IBaseRepositoryAsync<TEntity> where TEntity : class
    {
        private readonly IApplicationDbContext _context;
        private readonly IMongoCollection<TEntity> _dbCollection;

        public BaseRepositoryAsync(IApplicationDbContext context)
        {
            _context = context;
            _dbCollection = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            await _dbCollection.InsertOneAsync(entity);
        }

        public virtual void DeleteAsync(string id)
        {
            var objectId = new ObjectId(id);
            _dbCollection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", objectId));
        }

        public virtual async Task<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> filter) =>
            await _dbCollection.Find<TEntity>(filter).FirstOrDefaultAsync();

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() =>
            await _dbCollection.Find(entity => true).ToListAsync();

        public virtual async Task<TEntity> GetOneAsync(string id)
        {
            var objectId = new ObjectId(id);
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objectId);
            return await _dbCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetPageListAsync(int pageNumber, int pageSize) 
            => await _dbCollection.Find<TEntity>(entity => true)
                .Skip((pageNumber-1)* pageSize)
                  .Limit(pageSize)
                    .ToListAsync();

        public virtual async Task UpdateAsync(string id, TEntity entity)
        {
            var objectId = new ObjectId(id);
            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objectId);
            await _dbCollection.ReplaceOneAsync(filter, entity);
        }
    }
}
