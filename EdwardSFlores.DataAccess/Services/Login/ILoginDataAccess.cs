using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Login;

namespace EdwardSFlores.DataAccess.Services.Login;

public interface ILoginDataAccess
{
    UserLoginOutputModel? Login(string username, string password);
    
}

public class LoginDataAccess: ILoginDataAccess
{
    private readonly ILogicDataAccessDatabaseRepositoryLogin _logicDataAccessDatabaseRepositoryLogin;
    

    public LoginDataAccess(ILogicDataAccessDatabaseRepositoryLogin logicDataAccessDatabaseRepositoryLogin)
    {
        _logicDataAccessDatabaseRepositoryLogin = logicDataAccessDatabaseRepositoryLogin;
    }
    
    
    public UserLoginOutputModel? Login(string username, string password)
    {
        
        var user = _logicDataAccessDatabaseRepositoryLogin.Login(username, password);
        
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