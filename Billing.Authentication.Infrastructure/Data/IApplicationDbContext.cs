using MongoDB.Driver;

namespace Billing.Authentication.Infrastructure.Data
{
    public interface IApplicationDbContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>(string name);
    }
}
