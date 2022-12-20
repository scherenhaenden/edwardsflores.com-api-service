using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Repositories;

namespace EdwardSFlores.DataAccess.Database.Core.Unities
{
    public interface IGenericUnitOfWork: IDisposable
    {
        public IRepository<Role> Role { get; set; }

        public IRepository<User?> Users { get; set; }
        
        public IRepository<JobStation> JobStations { get; set; }
        
        public IRepository<Technology> Technologies { get; set; }

        public bool Save();
    }
}