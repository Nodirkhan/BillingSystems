using Billing.UserApi.Domains;
using Billing.UserApi.Domains.Entities;
using MongoDB.Driver;

namespace Billing.UserApi.Infrstructure.Data
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        private readonly IMongoDatabase _db;
        public IMongoCollection<User> UserCollection { get; set; }
        public ApplicationDbContext()
        {
            var client = new MongoClient(ConnectionSetting.ConnectionString);
            _db = client.GetDatabase(ConnectionSetting.DataBase);
            UserCollection = _db.GetCollection<User>(ConnectionSetting.UserCollection);

        }
    }
}
