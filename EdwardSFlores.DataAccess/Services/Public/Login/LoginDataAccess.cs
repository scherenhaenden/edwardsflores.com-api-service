using EdwardSFlores.DataAccess.Database.Persistence.Unities.ServiceUnities;
using EdwardSFlores.DataAccess.Models;

namespace EdwardSFlores.DataAccess.Services.Public.Login;

public class LoginDataAccess: ILoginDataAccess
{
    private readonly IPublicUserUnity _ipUserUnity;
    public LoginDataAccess(IPublicUserUnity ipUserUnity)
    {
        _ipUserUnity = ipUserUnity;
 
    }
    
    
    public UserDataAccessOutputModel? Login(string usernameOrEmail, string password)
    {
        
        var user = _ipUserUnity.Users.Login(usernameOrEmail, password);
        
        if (user == null)
            return null;

        var resultRoles = user.UserRoles.Select(x =>

                new UserRoleOutputModel()
                {
                    Guid = x.Guid,
                    Name = x.Name
                }

            )

            .ToList();
        // map user to UserLoginOutputModel
        var userLoginOutputModel = new UserDataAccessOutputModel();
        userLoginOutputModel.Guid = user.Guid;
        userLoginOutputModel.Username = user.Username;
        userLoginOutputModel.UserRoles = resultRoles;
        userLoginOutputModel.Email = user.Email;
        return userLoginOutputModel;
    }

    public bool? NewPassword(string usernameOrEmail, string password)
    {
        var user = _ipUserUnity.Users.NewPassword(usernameOrEmail, password);
        if (user != null)
        {
            return true;
        }

        return false;
    }
}