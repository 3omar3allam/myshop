using System.Linq.Expressions;

namespace MyShop.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> Join<TNavigation>(Expression<Func<TEntity, TNavigation>> include, Expression<Func<TNavigation, object>>? thenInclude = null);
        IQueryable<TEntity> Join<TNavigation>(IQueryable<TEntity> query, Expression<Func<TEntity, TNavigation>> include, Expression<Func<TNavigation, object>>? thenInclude = null);
        Task InsertAsync(TEntity entity, CancellationToken cancellationToken);
        Task InsertManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
        Task DeleteManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
        Task<IList<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
        Task<T?> FirstOrDefaultAsync<T>(IQueryable<T> query, CancellationToken cancellationToken);
        Task<IList<T>> ToListAsync<T>(IQueryable<T> query, CancellationToken cancellationToken) where T : class;
    }
}
