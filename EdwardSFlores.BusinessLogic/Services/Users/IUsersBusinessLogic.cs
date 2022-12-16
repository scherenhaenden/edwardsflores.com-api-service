using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Services.Public.Users;

namespace EdwardSFlores.BusinessLogic.Services.Users;

public interface IUsersBusinessLogic
{
    List<User?> GetUsers();
}

public class UsersBusinessLogic : IUsersBusinessLogic
{
    private readonly IUsersDataAccessService _usersRepository;

    public UsersBusinessLogic(IUsersDataAccessService usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public List<User?> GetUsers()
    {
        return _usersRepository.GetUsers();
    }
}