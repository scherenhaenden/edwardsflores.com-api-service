using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Repositories;

namespace EdwardSFlores.DataAccess.Database.Core.Unities
{
    public interface IUnitOfWork: IDisposable
    {
        public IRepository<Role> Role { get; set; }

        public IRepository<User> User { get; set; }

        public bool Save();
    }
}