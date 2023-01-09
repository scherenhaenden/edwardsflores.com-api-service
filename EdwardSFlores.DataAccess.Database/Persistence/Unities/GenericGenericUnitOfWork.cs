using EdwardSFlores.DataAccess.Database.Core.BaseDomain;
using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Repositories;
using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Persistence.Configuration;
using EdwardSFlores.DataAccess.Database.Persistence.Repositories;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace EdwardSFlores.DataAccess.Database.Persistence.Unities
{
    public class GenericGenericUnitOfWork: IGenericUnitOfWork
    {
        private readonly DbContextEdward _context;
    
        public GenericGenericUnitOfWork(DbContextEdward context)
        {
            _context = context;
            

            Role = InitObjects<Role>();
            Users = InitObjects<User>();
            JobStations = InitObjects<JobStation>();
            Technologies = InitObjects<Technology>();
            Organizations = InitObjects<Organization>();
        }
    
        private  IRepository<T> InitObjects<T>()  where T : BaseEntity
        {
            return  new GenericRepository<T>(_context);
        }

        public IRepository<Role> Role { get; set; }
        public IRepository<User?> Users { get; set; }
        public IRepository<JobStation> JobStations { get; set; }
        public IRepository<Technology> Technologies { get; set; }
        
        // Organization
        public IRepository<Organization> Organizations { get; set; }
        
        // Project
        public IRepository<Project> Projects { get; set; }
        
        // Token
        public IRepository<Token> Tokens { get; set; }

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

