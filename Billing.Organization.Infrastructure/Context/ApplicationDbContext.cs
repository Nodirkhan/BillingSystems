using Microsoft.EntityFrameworkCore;
using Billing.Organization.Domains.Entities;

namespace Billing.Organization.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
        }

        DbSet<Domains.Entities.Organization> Organizations { get; set; }
        DbSet<Institution> Institutions { get; set; }
        DbSet<Service> Services { get; set; }
    }
}
