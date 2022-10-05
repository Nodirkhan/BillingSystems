using Billing.Authentication.Domains.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Billing.Authentication.Infrastructure.Data
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        private readonly IMongoDatabase _db;
        public ApplicationDbContext(IOptions<ConnectionSetting> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>(string name) =>
            _db.GetCollection<TEntity>(name);

    }
}
