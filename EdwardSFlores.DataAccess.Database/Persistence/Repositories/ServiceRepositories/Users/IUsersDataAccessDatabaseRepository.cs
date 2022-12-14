using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Persistence.Configuration;
using Renci.SshNet;

namespace EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;

public interface IUsersDataAccessDatabaseRepository
{
    List<User> GetAll();
}
public class UsersDataAccessDatabaseRepository: GenericRepository<User>, IUsersDataAccessDatabaseRepository
{
    private readonly DbContextEdward _dbContextEdward;
    
    public UsersDataAccessDatabaseRepository(IDataContextManager dataContextManager): base(dataContextManager.DbContextEdward)
    {
        _dbContextEdward = dataContextManager.DbContextEdward;
    }


    public UsersDataAccessDatabaseRepository(DbContextEdward dbContextEdward): base(dbContextEdward)
    {
        _dbContextEdward = dbContextEdward;
    }
    
    
    public List<User> GetAll()
    {
        return _dbContextEdward.Users.ToList();
    }
    

}
