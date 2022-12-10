using System.Linq.Expressions;
using EdwardSFlores.DataAccess.Database.Core.BaseDomain;

namespace EdwardSFlores.DataAccess.Database.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, IBaseEntity
    {
        public IQueryable<TEntity> GetAll();
        TEntity? Get(Guid id);
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    
        TEntity Update(TEntity entity);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);
        TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
    
        IEnumerable<TEntity>? Where(Expression<Func<TEntity, bool>> predicate);
    }
}