namespace EdwardSFlores.BusinessLogic.Services.Login;

public interface ILoginBusinessLogic
{
    UserLoginBusinessOut? Login(string username, string password);
    
    UserLoginBusinessOut? Login(UserLoginBusinessIn userLoginBusinessIn);
    
    bool NewPassword(string username, string password);
}