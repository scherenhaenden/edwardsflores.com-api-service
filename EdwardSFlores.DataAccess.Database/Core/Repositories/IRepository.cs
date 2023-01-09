using System.Linq.Expressions;
using EdwardSFlores.DataAccess.Database.Core.BaseDomain;
using EdwardSFlores.DataAccess.Database.Core.Domain;

namespace EdwardSFlores.DataAccess.Database.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, IBaseEntity
    {
        public IQueryable<TEntity> GetAll();
        
        // get all with pagination
        public IQueryable<TEntity> GetAll(int page, int pageSize);
        
        TEntity? GetByGuid(Guid id);
        Task<TEntity?> GetByGuidAsync(Guid guid, CancellationToken cancellationToken = default);
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    
        TEntity Update(TEntity entity);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        
        TEntity Remove(TEntity entity);
        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);
        TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        
        TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
    
        IEnumerable<TEntity>? Where(Expression<Func<TEntity, bool>> predicate);
    }
}