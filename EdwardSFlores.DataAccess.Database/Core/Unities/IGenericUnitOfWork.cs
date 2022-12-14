using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Repositories;
using EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Login;

namespace EdwardSFlores.DataAccess.Database.Core.Unities
{
    public interface IGenericUnitOfWork: IDisposable
    {
        public IRepository<Role> Role { get; set; }

        public IRepository<User> User { get; set; }

        public bool Save();
    }

    public interface IServicesUnitOfWork : IDisposable
    {
        ILogicDataAccessDatabaseRepositoryLogin Login { get; set; }
    }
}