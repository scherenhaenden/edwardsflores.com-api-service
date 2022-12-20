using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;

namespace EdwardSFlores.DataAccess.Database.Persistence.Unities.ServiceUnities;

public interface IPublicUserUnity: IGenericUnitOfWork
{
    public IUsersDataAccessDatabaseRepository Users { get;  }
    public IJobsStationsDataAccessDatabase Jobs { get; }
    
    public ITechnologiesDataAccessDatabase Technologies { get; }
    
    public IRolesDataAccessDatabase Role { get; }

}