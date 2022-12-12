namespace EdwardSFlores.Service.Chaos;

public interface IUserService
{
    /*
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);*/
    object? GetById(int userId);
}