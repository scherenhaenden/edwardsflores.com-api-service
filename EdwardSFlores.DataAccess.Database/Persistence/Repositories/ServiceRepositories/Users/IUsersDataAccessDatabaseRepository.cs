using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Persistence.Configuration;

namespace EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;

public interface IUsersDataAccessDatabaseRepository
{
    List<User?> GetAll();
    
    User? Login(string username, string password);
}
public class UsersDataAccessDatabaseRepository: GenericRepository<User>, IUsersDataAccessDatabaseRepository
{
    private readonly DbContextEdward _dbContextEdward;
    private readonly IGenericUnitOfWork _genericUnitOfWork;
    
    public UsersDataAccessDatabaseRepository(IDataContextManager dataContextManager): base(dataContextManager.DbContextEdward)
    {
        _dbContextEdward = dataContextManager.DbContextEdward;
        _genericUnitOfWork = dataContextManager.GenericUnityOfWork;
    }


    public UsersDataAccessDatabaseRepository(DbContextEdward dbContextEdward): base(dbContextEdward)
    {
        _dbContextEdward = dbContextEdward;
    }
    
    
    public List<User?> GetAll()
    {
        return _genericUnitOfWork.Users.GetAll().ToList();
    }

    public User? Login(string username, string password)
    {
        
        return _genericUnitOfWork?.Users?
        
            .Where(x => x.Username == username && x.Password == password)?
            .Select(o =>
                new User()
                {
                    Username = o.Username,
                    Email = o.Email,
                    UserRoles = o.UserRoles
                })?
            .FirstOrDefault();
    }
}
