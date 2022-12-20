using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Persistence.Configuration;
using EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;
using EdwardSFlores.DataAccess.Database.Security;

namespace EdwardSFlores.DataAccess.Database.Persistence.Unities.ServiceUnities;

public class PublicUserUnity : GenericGenericUnitOfWork, IPublicUserUnity
{
    public PublicUserUnity(DbContextEdward context, IPasswordHasher passwordHasher) : base(context)
    {
        Users = new UsersDataAccessDatabaseRepository(context, passwordHasher);
    }
    
    public PublicUserUnity(IDataContextManager dataContextManager) : base(dataContextManager.DbContextEdward)
    {
        Role = new RolesDataAccessDatabase(dataContextManager);
    }
    
    public PublicUserUnity(IDataContextManager dataContextManager, IPasswordHasher passwordHasher) : base(dataContextManager.DbContextEdward)
    {
        Users = new UsersDataAccessDatabaseRepository(dataContextManager.DbContextEdward,passwordHasher);
        Jobs = new JobsStationsDataAccessDatabase(dataContextManager);
        Technologies = new TechnologiesDataAccessDatabase(dataContextManager);
        Role = new RolesDataAccessDatabase(dataContextManager);
    }

    public IUsersDataAccessDatabaseRepository Users { get; private set; }
    public IJobsStationsDataAccessDatabase Jobs { get; private set; }
    
    public ITechnologiesDataAccessDatabase Technologies { get; private set; }
    
    public IRolesDataAccessDatabase Role { get; private set; }


}

   