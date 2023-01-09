using EdwardSFlores.DataAccess.Models;

namespace EdwardSFlores.DataAccess.Services.Public.Login;

public interface ILoginDataAccess
{
    UserDataAccessOutputModel? Login(string usernameOrEmail, string password);
    
    bool? NewPassword(string usernameOrEmail, string password);
    
}