using EdwardSFlores.DataAccess.Services.Public.Users;

namespace EdwardSFlores.BusinessLogic.Services.Login;

public class LoginBusinessLogic : ILoginBusinessLogic
{
    private readonly IUsersDataAccessService _usersDataAccessService;

    public LoginBusinessLogic(IUsersDataAccessService usersDataAccessService)
    {
        _usersDataAccessService = usersDataAccessService;
    }

    public UserLoginBusinessOut? Login(string username, string password)
    {
        var userLoginBusinessIn = new UserLoginBusinessIn
        {
            Username = username,
            Password = password
        };

        return Login(userLoginBusinessIn);
    }

    public UserLoginBusinessOut? Login(UserLoginBusinessIn userLoginBusinessIn)
    {
        var userLoginBusinessOut = new UserLoginBusinessOut();

       
        
        var result =_usersDataAccessService.Login(userLoginBusinessIn.Username, userLoginBusinessIn.Password);
        
        if(result == null)
        {
            return null;
        }
        userLoginBusinessOut.IsAuthenticated = true;
        userLoginBusinessOut.Username = result.Username;
        userLoginBusinessOut.Guid = result.Guid;
        userLoginBusinessOut.Email = result.Email;
        return userLoginBusinessOut;
    }

    public bool NewPassword(string username, string password)
    {


        return _usersDataAccessService.NewPassword(username, password);
    }
}