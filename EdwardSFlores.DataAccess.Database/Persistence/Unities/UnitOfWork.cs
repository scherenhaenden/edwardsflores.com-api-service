using EdwardSFlores.DataAccess.Database.Core.BaseDomain;
using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Repositories;
using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Persistence.Configuration;
using EdwardSFlores.DataAccess.Database.Persistence.Repositories;

namespace EdwardSFlores.DataAccess.Database.Persistence.Unities
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DbContextEdward _context;
    
        public UnitOfWork(DbContextEdward context)
        {
            _context = context;

            Role = InitObjects<Role>();
            User = InitObjects<User>();
        }
    
        private  IRepository<T> InitObjects<T>()  where T : BaseEntity
        {
            return  new Repository<T>(_context);
        }

        public IRepository<Role> Role { get; set; }
        public IRepository<User> User { get; set; }
        public bool Save()
        {
            var result = _context.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

