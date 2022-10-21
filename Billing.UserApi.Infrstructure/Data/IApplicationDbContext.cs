using Billing.UserApi.Domains.Entities;
using MongoDB.Driver;

namespace Billing.UserApi.Infrstructure.Data
{
    public interface IApplicationDbContext
    {
        IMongoCollection<User> UserCollection { get; set; }
    }
}
