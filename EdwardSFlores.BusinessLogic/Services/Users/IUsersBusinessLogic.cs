using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Models;
using EdwardSFlores.DataAccess.Services.Public.Login;
using EdwardSFlores.DataAccess.Services.Public.Users;

namespace EdwardSFlores.BusinessLogic.Services.Users;

public interface IUsersBusinessLogic
{
    List<UserDataAccessOutputModel?> GetUsers();
    
    UserDataAccessOutputModel? GetUserById(Guid guid);
}

public class UsersBusinessLogic : IUsersBusinessLogic
{
    private readonly IUsersDataAccessService _usersRepository;

    public UsersBusinessLogic(IUsersDataAccessService usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public List<UserDataAccessOutputModel?> GetUsers()
    {
        return _usersRepository.GetUsers();
    }

    public UserDataAccessOutputModel? GetUserById(Guid guid)
    {
        return _usersRepository.GetUserById(guid);
    }
}