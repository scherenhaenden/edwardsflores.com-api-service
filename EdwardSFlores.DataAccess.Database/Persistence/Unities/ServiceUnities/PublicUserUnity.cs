using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Persistence.Configuration;
using EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;

namespace EdwardSFlores.DataAccess.Database.Persistence.Unities.ServiceUnities;

public class PublicUserUnity:GenericGenericUnitOfWork, IPublicUserUnity
{
    

    public PublicUserUnity(DbContextEdward context) : base(context)
    {
        UsersDataAccessDatabaseRepository = new UsersDataAccessDatabaseRepository(context);
    }
    

    public IUsersDataAccessDatabaseRepository UsersDataAccessDatabaseRepository { get; }

    public User? GetLoginAsync(string username, string password)
    {
        var user = Users
            .Where(x => x.Username == username && x.Password == password)
            .Select(o =>
                new User()
                {
                    Username = o.Username,
                    Email = o.Email,
                    UserRoles = o.UserRoles
                })
            .FirstOrDefault();
        return user;
    }

    public List<User?>? GetAllUsers()
    {
        return UsersDataAccessDatabaseRepository.GetAll();
    }

    public User? GetUserById(Guid guid)
    {
        return Users?.GetByGuid(guid);
    }
}