using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;

namespace EdwardSFlores.DataAccess.Services.Users;

public interface IUsersDataAccessService
{
    List<User> GetUsers();

}

public class UsersDataAccessService: IUsersDataAccessService
{
    private readonly IUsersDataAccessDatabaseRepository _usersDataAccessDatabaseRepository;

    public UsersDataAccessService(IUsersDataAccessDatabaseRepository usersDataAccessDatabaseRepository)

    {
        _usersDataAccessDatabaseRepository = usersDataAccessDatabaseRepository;
    }
    
    
    public List<User> GetUsers()
    {
        return _usersDataAccessDatabaseRepository.GetAll();
        
        // map list of users to map of anonymous objects
        


    }
}