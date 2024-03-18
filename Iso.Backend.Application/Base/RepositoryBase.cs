
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Iso.Backend.Application.Common.Interfaces;
using Iso.Backend.Domain.Entities.Base;

namespace Iso.Backend.Application.Base
{
    public abstract class RepositoryBase<TDomain, TContext> : IRepository<TDomain> where TDomain : DomainObject where TContext : DbContext
    {
        protected readonly TContext _db;

        protected RepositoryBase(TContext db)
        {
            _db = db;
        }

        public virtual async Task<TDomain> AddAsync(TDomain entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TDomain> FindAsync(
             Guid id,
             params Expression<Func<TDomain, object>>[] includes)
        {
            IQueryable<TDomain> query = _db.Set<TDomain>();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query
                    .Where(u => !u.IsDeleted && u.Id == id)
                    .SingleOrDefaultAsync().ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TDomain>> FindAsync(
            Expression<Func<TDomain, bool>> predicate,
            params Expression<Func<TDomain, object>>[] includes)
        {
            IQueryable<TDomain> query = _db.Set<TDomain>();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query
                .Where(predicate)
                .Where(u => !u.IsDeleted)
                .Where(u => u.IsActive)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public virtual async Task<TDomain> FindOneAsync(
            Expression<Func<TDomain, bool>> predicate,
            params Expression<Func<TDomain, object>>[] includes)
        {
            IQueryable<TDomain> query = _db.Set<TDomain>();
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return await query
                .Where(predicate)
                .Where(u => !u.IsDeleted)
                .Where(u => u.IsActive)
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);
        }

        public virtual async Task DeleteAsync(TDomain entity)
        {
            _db.Remove(entity);
            await _db.SaveChangesAsync()
                     .ConfigureAwait(false);
        }

        /// <summary>
        /// Remove - Soft Delete
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task RemoveAsync(TDomain entity)
        {
            entity.IsDeleted = true;
            entity.Modified = DateTime.UtcNow;
            _db.Update(entity);
            await _db
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public virtual async Task UpdateAsync(TDomain entity)
        {
            entity.Modified = DateTime.UtcNow;
            _db.Update(entity);
            await _db
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}
