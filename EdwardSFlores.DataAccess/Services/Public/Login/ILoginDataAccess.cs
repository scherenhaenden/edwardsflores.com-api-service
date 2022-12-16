using EdwardSFlores.DataAccess.Database.Persistence.Unities.ServiceUnities;

namespace EdwardSFlores.DataAccess.Services.Public.Login;

public interface ILoginDataAccess
{
    UserLoginOutputModel? Login(string username, string password);
    
}

public class LoginDataAccess: ILoginDataAccess
{
    private readonly IPublicUserUnity _ipUserUnity;
    public LoginDataAccess(IPublicUserUnity ipUserUnity)
    {
        _ipUserUnity = ipUserUnity;
 
    }
    
    
    public UserLoginOutputModel? Login(string username, string password)
    {
        
        var user = _ipUserUnity.GetLoginAsync(username, password);
        
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
        var userLoginOutputModel = new UserLoginOutputModel();
        userLoginOutputModel.Guid = user.Guid;
        userLoginOutputModel.Username = user.Username;
        userLoginOutputModel.UserRoles = resultRoles;
        userLoginOutputModel.Email = user.Email;
        return userLoginOutputModel;
    }
}