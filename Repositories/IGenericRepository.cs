using System.Linq.Expressions;

namespace TihomirsBakery.Repositories
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> GetAll(CancellationToken cancellationToken, Expression<Func<TEntity, bool>> predicate = null);
        TEntity Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Attach(TEntity entity);
    }
}