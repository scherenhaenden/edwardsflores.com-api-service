using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Persistence.Unities.ServiceUnities;

namespace EdwardSFlores.DataAccess.Services.Public.Users;

public interface IUsersDataAccessService
{
    List<User?>? GetUsers();

}

public class UsersDataAccessService: IUsersDataAccessService
{
    private readonly IPublicUserUnity _publicUserUnity;


    public UsersDataAccessService(IPublicUserUnity publicUserUnity)

    {
        _publicUserUnity = publicUserUnity;
    }
    
    
    public List<User?>? GetUsers()
    {
        return _publicUserUnity.GetAllUsers();
    }
}