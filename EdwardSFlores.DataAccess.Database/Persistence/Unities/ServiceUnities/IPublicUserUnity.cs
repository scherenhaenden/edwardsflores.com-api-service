using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;

namespace EdwardSFlores.DataAccess.Database.Persistence.Unities.ServiceUnities;

public interface IPublicUserUnity
{
    IUsersDataAccessDatabaseRepository UsersDataAccessDatabaseRepository { get; }
    User? GetLoginAsync(string username, string password);

    List<User?>? GetAllUsers();
    
    User? GetUserById(Guid guid);
}