using Billing.Authentication.Domains.Entities;
using Billing.Authentication.Infrastructure.Data;
using Billing.Authentication.Infrastructure.Interface;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Billing.Authentication.Infrastructure.Repositories
{
    public class UserRepositoryAsync : BaseRepositoryAsync<User>, IUserRepositoryAsync
    {
        private readonly IApplicationDbContext _context;
        private readonly IMongoCollection<User> _userCollection;
        public UserRepositoryAsync(IApplicationDbContext context) : base(context)
        {
            _context = context;
            _userCollection = _context.GetCollection<User>(typeof(User).Name);
        }

        public async Task<User> LoginAsync(string username, string password) =>
           await  FindByConditionAsync(u => u.UserName == username && u.Password == password);
    }
}
