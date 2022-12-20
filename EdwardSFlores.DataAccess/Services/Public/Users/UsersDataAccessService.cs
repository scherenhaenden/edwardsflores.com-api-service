using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Persistence.Unities.ServiceUnities;
using EdwardSFlores.DataAccess.Database.Security;
using EdwardSFlores.DataAccess.Services.Public.Login;

namespace EdwardSFlores.DataAccess.Services.Public.Users;

public class UsersDataAccessService: IUsersDataAccessService
{
    private readonly IPublicUserUnity _publicUserUnity;

    public UsersDataAccessService(IDataContextManager dataContextManager, IPasswordHasher passwordHasher)

    {
        _publicUserUnity = new PublicUserUnity(dataContextManager, passwordHasher);
    }
    
    
    public List<UserDataAccessOutputModel?>? GetUsers()
    {
        var result = _publicUserUnity.Users.GetAllUsers();
        if(result == null)
            return null;

        return result.Select(MapUserToOutputModel).ToList();
    }

    public UserDataAccessOutputModel? GetUserById(Guid guid)
    {
        var result = _publicUserUnity.Users.GetByGuid(guid);
        if(result == null) return null;
        return MapUserToOutputModel(result);
        
        
    }
   
    public UserDataAccessOutputModel? Login(string email, string password)
    {
        
        var result = _publicUserUnity.Users.Login(email, password);
        
        if (result == null)
        {
            return null;
        }
        return MapUserToOutputModel(result);
    }

    public bool NewPassword(string userOrEmail, string password)
    {
        var user = _publicUserUnity.Users.NewPassword(userOrEmail, password);
        if (user != null)
        {
            return true;
        }

        return false;
    }

    // Create method to map user to output model
    private UserDataAccessOutputModel? MapUserToOutputModel(User user)
    {
        if (user == null)
        {
            return null;
        }
        return new UserDataAccessOutputModel
        {
            Guid = user.Guid,
            Email = user.Email,
            Username = user.Username,
        };
    }
}