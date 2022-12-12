namespace EdwardSFlores.BusinessLogic.Services.Login;

public interface ILoginBusinessLogic
{
    UserLoginBusinessOut Login(string username, string password);
    
    UserLoginBusinessOut Login(UserLoginBusinessIn userLoginBusinessIn);
}

// Create model for login result
public class LoginResult
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public string Token { get; set; }
}


// Create model for User Login
public class UserLoginBusinessIn
{
    public string Username { get; set; }
    public string Password { get; set; }
}

// Create model for User information
public class UserLoginBusinessOut
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public bool IsAuthenticated { get; set; }
}