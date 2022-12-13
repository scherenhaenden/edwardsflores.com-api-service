using EdwardSFlores.BusinessLogic.Tools;

namespace EdwardSFlores.BusinessLogic.Services.Login;

public class LoginBusinessLogic : ILoginBusinessLogic
{
    private readonly IPasswordHasher _passwordHasher;

    public LoginBusinessLogic( IPasswordHasher passwordHasher)
    {

        _passwordHasher = passwordHasher;
    }

    public UserLoginBusinessOut Login(string username, string password)
    {
        var userLoginBusinessIn = new UserLoginBusinessIn
        {
            Username = username,
            Password = password
        };

        return Login(userLoginBusinessIn);
    }

    public UserLoginBusinessOut Login(UserLoginBusinessIn userLoginBusinessIn)
    {
        var userLoginBusinessOut = new UserLoginBusinessOut();

        if (userLoginBusinessIn.Username == "admin" && _passwordHasher.VerifyHashedPassword(userLoginBusinessIn.Password, "admin"))
        {
            userLoginBusinessOut.IsAuthenticated = true;
            userLoginBusinessOut.Username = userLoginBusinessIn.Username;
        }

        return userLoginBusinessOut;
    }
}