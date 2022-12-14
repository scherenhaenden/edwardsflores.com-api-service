using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Repositories;
using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Persistence.Configuration;

namespace EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Login;

public interface ILogicDataAccessDatabaseRepositoryLogin : IRepository<User> 
{
    User? Login(string username, string password);
}


public class LogicDataAccessDatabaseGenericRepositoryLogin : GenericRepository<User>, ILogicDataAccessDatabaseRepositoryLogin
{
    private readonly DbContextEdward _dbContextEdward;
    
    public LogicDataAccessDatabaseGenericRepositoryLogin(IDataContextManager dataContextManager): base(dataContextManager.DbContextEdward)
    {
        _dbContextEdward = dataContextManager.DbContextEdward;
    }


    public LogicDataAccessDatabaseGenericRepositoryLogin(DbContextEdward dbContextEdward): base(dbContextEdward)
    {
        _dbContextEdward = dbContextEdward;
    }

    public User? Login(string username, string password)
    {
        return _dbContextEdward.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
    }
}
