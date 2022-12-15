using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EdwardSFlores.DataAccess.Database.ContextManagement;

public interface IDataContextManager
{
    public DbContextEdward DbContextEdward { get; }
    
    public IGenericUnitOfWork GenericUnityOfWork { get; }
    
}