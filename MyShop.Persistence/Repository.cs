using Microsoft.EntityFrameworkCore;
using MyShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Persistence
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MyShopDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(MyShopDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IQueryable<TEntity> Table => _context.Set<TEntity>();

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            if (entity is ISoftDeletable softDeletable)
            {
                softDeletable.IsDeleted = true;
                _dbSet.Update(entity);
            }
            else
            {
                _dbSet.Remove(entity);
            }
            await SaveAsync(cancellationToken);
        }

        public async Task DeleteManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            if (typeof(TEntity).IsAssignableTo(typeof(ISoftDeletable)))
            {
                foreach(var entity in entities)
                {
                    ((ISoftDeletable)entity).IsDeleted = true;
                    _dbSet.Update(entity);
                }
            }
            else
            {
                _dbSet.RemoveRange(entities);
            }
            await SaveAsync(cancellationToken);
        }

        public async Task InsertAsync(TEntity entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            await SaveAsync(cancellationToken);
        }

        public async Task InsertManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
        {
            await _dbSet.AddRangeAsync(entities, cancellationToken);
            await SaveAsync(cancellationToken);
        }

        public IQueryable<TEntity> Join<TNavigation>(Expression<Func<TEntity, TNavigation>> include, Expression<Func<TNavigation, object>>? thenInclude = null)
        {
            return Join(Table, include, thenInclude);
        }

        public IQueryable<TEntity> Join<TNavigation>(IQueryable<TEntity> query, Expression<Func<TEntity, TNavigation>> include, Expression<Func<TNavigation, object>>? thenInclude = null)
        {
            var result = query.Include(include);
            if (thenInclude is not null)
            {
                return result.ThenInclude(thenInclude);
            }
            return result;
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            _dbSet.Update(entity);
            await SaveAsync(cancellationToken);
        }

        public async Task<IList<T>> ToListAsync<T>(IQueryable<T> query, CancellationToken cancellationToken)
            where T : class
        {
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<IList<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _dbSet.Where(predicate).ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> query, CancellationToken cancellationToken)
        {
            return await query.FirstOrDefaultAsync(cancellationToken);
        }
        private Task<int> SaveAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
