using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Persistence.Configuration;
using EdwardSFlores.DataAccess.Database.Persistence.Unities;
using EdwardSFlores.DataAccess.Database.Security;

namespace EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;

public class UsersDataAccessDatabaseRepository: GenericRepository<User>, IUsersDataAccessDatabaseRepository
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly DbContextEdward _dbContextEdward;
    private readonly IGenericUnitOfWork _genericUnitOfWork;
    
    public UsersDataAccessDatabaseRepository(IDataContextManager dataContextManager, IPasswordHasher passwordHasher): base(dataContextManager.DbContextEdward)
    {
        _passwordHasher = passwordHasher;
        _dbContextEdward = dataContextManager.DbContextEdward;
        _genericUnitOfWork = dataContextManager.GenericUnityOfWork;
    }


    public UsersDataAccessDatabaseRepository(DbContextEdward dbContextEdward, IPasswordHasher passwordHasher): base(dbContextEdward)
    {
        _dbContextEdward = dbContextEdward;
        _passwordHasher = passwordHasher;
        _genericUnitOfWork = new GenericGenericUnitOfWork(dbContextEdward);
        
    }
    
    public new List<User?> GetAll()
    {
        return _genericUnitOfWork.Users.GetAll().ToList();
    }
    
    public new User? Add(User user)
    {
        user.Password = _passwordHasher.HashPassword(user.Password);
        return _genericUnitOfWork.Users.Add(user);
    }

    public User? Login(string usernameOrEmail, string password)
    {
        var toBeVerified = _genericUnitOfWork.Users.GetAll()
            .FirstOrDefault(x => x.Username == usernameOrEmail || x.Email == usernameOrEmail).Password;
        if (string.IsNullOrEmpty(toBeVerified))
        {
            return null;
        }
        //password=_passwordHasher.HashPassword(password);
        var verified= _passwordHasher.VerifyHashedPassword(toBeVerified, password );
        if (verified == false)
        {
            return null;
        }
        
        return _genericUnitOfWork?.Users?
            .Where(x => (x.Username == usernameOrEmail || x.Email == usernameOrEmail))?
            .Select(o =>
                new User()
                {
                    Username = o.Username,
                    Email = o.Email,
                    UserRoles = o.UserRoles,
                    Guid = o.Guid
                })?
            .FirstOrDefault();
    }

    public User? NewPassword(string usernameOrEmail, string password)
    {

        
        
        var user = _genericUnitOfWork?.Users?
            .Where(x => (x.Username == usernameOrEmail || x.Email == usernameOrEmail))?
            .FirstOrDefault();
        if (user != null)
        {
            user.Password = _passwordHasher.HashPassword(password);
            _genericUnitOfWork?.Users?.Update(user);
            _genericUnitOfWork?.Save();
        }

        return user;
    }

    public List<User?>? GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public User? GetUserById(Guid guid)
    {
        throw new NotImplementedException();
    }

    public User? GetUserByUsername(string username)
    {
        throw new NotImplementedException();
    }

    public User? GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }
}