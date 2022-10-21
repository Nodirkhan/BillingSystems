using Billing.UserApi.Domains.Entities;
using Billing.UserApi.Infrstructure.Data;
using Billing.UserApi.Infrstructure.Interface;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Billing.UserApi.Infrstructure.Repository
{
    public class UserRepositoryAsync : IUserRepositoryAsync
    {
        private readonly IApplicationDbContext _context;
        private readonly IMongoCollection<User> _userCollection;

        public UserRepositoryAsync(IApplicationDbContext context)
        {
            _context = context;
            _userCollection = _context.UserCollection;
        }
        public async Task DeleteAsync(string id)
        {
            var objectId = new ObjectId(id);
            await _userCollection.DeleteOneAsync(Builders<User>.Filter.Eq("_id", objectId));
        }

        public async Task<User> FindbyCondition(Expression<Func<User, bool>> expression) =>
            await _userCollection.Find<User>(expression).FirstOrDefaultAsync();

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _userCollection.Find(users => true).ToListAsync();

        public async Task<(IEnumerable<User> users, long totalCount)> GetPageListAsync(int pageNumber, int pageSize)
        {
            var users = await _userCollection.Find(user => true)
                 .Skip((pageNumber - 1) * pageSize)
                     .Limit(pageSize)
                       .ToListAsync();

            long totalCount = await _userCollection.Find(user => true).CountDocumentsAsync();
            
            return (users, totalCount);
        }
          

        public async Task InsertAsync(User user)
        {
            user.SetCreatedDateTime();
            user.SetPermission();
            user.SetRole();

            await _userCollection.InsertOneAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            var objectId = new ObjectId(user.Id);
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("_id", objectId);
            await _userCollection.ReplaceOneAsync(filter, user);
        }

        public async Task<bool> IsExist(string userName) =>
            await _userCollection.Find(u => u.UserName == userName).AnyAsync();
    }
}
