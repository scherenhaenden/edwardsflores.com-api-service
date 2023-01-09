using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Persistence.Configuration;

namespace EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;

public class TechnologiesDataAccessDatabase : GenericRepository<Technology>, ITechnologiesDataAccessDatabase
{
    private readonly DbContextEdward _dbContextEdward;
    private readonly IGenericUnitOfWork _genericUnitOfWork;
    
    public TechnologiesDataAccessDatabase(IDataContextManager dataContextManager): base(dataContextManager.DbContextEdward)
    {
        
        _dbContextEdward = dataContextManager.DbContextEdward;
        _genericUnitOfWork = dataContextManager.GenericUnityOfWork;
    }

    public List<Technology?> GetAllTechnologies()
    {
        return _genericUnitOfWork.Technologies.GetAll().ToList();
    }

    public Technology? GetTechnologyByGuid(Guid guid)
    {
        return _genericUnitOfWork.Technologies.GetByGuid(guid);
    }

    public Technology? GetTechnologyByName(string name)
    {
        return _genericUnitOfWork.Technologies.Where(x=>x.Name == name).FirstOrDefault();
    }

    public List<Technology?> SearchTechnologies(string text)
    {
        return _genericUnitOfWork.Technologies.Where(x=>x.Description.Contains(text.ToLower())).ToList();
    }

    public Technology? AddTechnology(Technology technology)
    {
        _genericUnitOfWork.Technologies.Add(technology);
        _genericUnitOfWork.Save();
        return technology;
    }

    public Technology? UpdateTechnology(Technology technology)
    {
        _genericUnitOfWork.Technologies.Update(technology);
        _genericUnitOfWork.Save();
        return technology;
    }

    public bool DeleteTechnology(Technology technology)
    {
        _genericUnitOfWork.Technologies.Remove(technology);
        _genericUnitOfWork.Save();
        return true;
    }

    public bool DeleteTechnologyByGuid(Guid guid)
    {
        var technology = _genericUnitOfWork.Technologies.GetByGuid(guid);
        if (technology != null)
        {
            return DeleteTechnology(technology);
        }
        return false;
    }
}