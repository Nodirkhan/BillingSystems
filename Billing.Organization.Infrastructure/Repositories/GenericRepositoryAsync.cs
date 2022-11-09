using Billing.Organization.Domains;
using Billing.Organization.Infrastructure.Context;
using Billing.Organization.Infrastructure.Intefaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Billing.Organization.Infrastructure.Repositories
{
    public abstract class GenericRepositoryAsync<TEntity> : IGenericRepositoryAsync<TEntity> where TEntity : Base
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepositoryAsync(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public virtual async Task CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveChangesAsync();
        }

        public virtual async Task<bool> DeleteAsync(Guid Id)
        {
            var entity = await _dbSet.FindAsync(Id);
            if (entity == null)
                return true;

            entity.ModifyEntity(entity.Id, active: false);
            return await SaveChangesAsync();
        }


        public virtual async Task<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> filter, List<string> tables)
        {
            IQueryable<TEntity> enities = _dbSet;
            foreach(string table in tables)
            {
                enities = enities.Include(table);
            }
            return await enities.FirstOrDefaultAsync(filter);
        }
        public virtual async Task<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> filter) =>
            await _dbSet.FirstOrDefaultAsync(filter);

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() =>
            await _dbSet.ToListAsync();

        public virtual async Task<TEntity> GetOneAsync(Guid id) =>
            await _dbSet.FindAsync(id);

        public virtual async Task<IEnumerable<TEntity>> GetPageListAsync(int pageNumber, int pageSize)
        {
            return await _dbSet.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await SaveChangesAsync(); 
        }

        public virtual void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveChangesAsync() =>
            await _context.SaveChangesAsync() > 0 ? true : false;
    }
}
