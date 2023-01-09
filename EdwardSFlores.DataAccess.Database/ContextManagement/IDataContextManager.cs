using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Persistence.Configuration;

namespace EdwardSFlores.DataAccess.Database.ContextManagement;

public interface IDataContextManager
{
    public DbContextEdward DbContextEdward { get; }
    
    public IGenericUnitOfWork GenericUnityOfWork { get; }
    
}