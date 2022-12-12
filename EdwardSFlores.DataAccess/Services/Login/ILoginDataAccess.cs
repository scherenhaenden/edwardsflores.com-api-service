using EdwardSFlores.DataAccess.Database.Core.Unities;

namespace EdwardSFlores.DataAccess.Services.Login;

public interface ILoginDataAccess
{
    UserLoginOutputModel? Login(string username, string password);
    
}

public class LoginDataAccess: ILoginDataAccess
{
    private readonly IUnitOfWork _unitOfWork;

    public LoginDataAccess(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    
    public UserLoginOutputModel? Login(string username, string password)
    {
        var user = _unitOfWork?.User?.Where(x=>x.Username == username && x.Password == password)?.FirstOrDefault();
        
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