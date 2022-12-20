using EdwardSFlores.DataAccess.Models;
using EdwardSFlores.DataAccess.Services.Public.Login;

namespace EdwardSFlores.DataAccess.Services.Public.Users;

public interface IUsersDataAccessService
{
    List<UserDataAccessOutputModel?>? GetUsers();
    
    UserDataAccessOutputModel? GetUserById(Guid id);
    
    UserDataAccessOutputModel? Login(string email, string password);
    
    bool NewPassword(string userOrEmail, string password);

}