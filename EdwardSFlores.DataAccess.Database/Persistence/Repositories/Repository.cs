using System.Linq.Expressions;
using EdwardSFlores.DataAccess.Database.Core.BaseDomain;
using EdwardSFlores.DataAccess.Database.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EdwardSFlores.DataAccess.Database.Persistence.Repositories
{
    public class Repository<TEntity> :IRepository<TEntity> where TEntity : BaseEntity, IBaseEntity
    {
        private readonly DbContext _context;
        public DbSet<TEntity> Entity { get; }
        public Repository(DbContext context)
        {
            try
            {
                _context = context;
                Entity = _context.Set<TEntity>();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                var valu =ex.InnerException?.Message.ToString();
            }

        }
    
        public IQueryable<TEntity> GetAll()
        {
            return Entity.AsNoTracking();
        }

        public TEntity? Get(Guid guid)
        {
            return Entity.SingleOrDefault(x => x.Guid == guid);
        }

        public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public TEntity Add(TEntity entity)
        {
            entity.OnNew();
            Entity.Add(entity);
            return entity;
        }

        public Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            entity.OnUpdate();
            var result = Entity.Update(entity);
            return result.Entity;
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Entity.SingleOrDefault(predicate);
        }

        public IEnumerable<TEntity>? Where(Expression<Func<TEntity, bool>> predicate)
        {
            return Entity.Where(predicate);
        }
    }
}