using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Repositories;

namespace EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;

public interface IUsersDataAccessDatabaseRepository: IRepository<User>
{
    List<User?> GetAll();
    
    User? Login(string usernameOrEmail, string password);
    
    User? NewPassword(string usernameOrEmail, string password);

    List<User?>? GetAllUsers();

    User? GetUserByUsername(string username);
    
    User? GetUserByEmail(string email);

}