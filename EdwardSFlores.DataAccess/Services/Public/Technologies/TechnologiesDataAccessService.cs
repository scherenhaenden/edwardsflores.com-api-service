using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Persistence.Unities.ServiceUnities;
using EdwardSFlores.DataAccess.Database.Security;
using EdwardSFlores.DataAccess.Models;
using EdwardSFlores.DataAccess.Services.Public.Jobs;
using Newtonsoft.Json;

namespace EdwardSFlores.DataAccess.Services.Public.Technologies;

public class TechnologiesDataAccessService : ITechnologiesDataAccessService
{
    private readonly IPublicUserUnity _publicUserUnity;

    public TechnologiesDataAccessService(IDataContextManager dataContextManager, IPasswordHasher passwordHasher)

    {
        _publicUserUnity = new PublicUserUnity(dataContextManager, passwordHasher);
    }

    public List<TechnologyDataAccessModel?> GetAllTechnologies()
    {
        var result = _publicUserUnity.Technologies.GetAll().ToList();
        // obj to json
        var json = JsonConvert.SerializeObject(result);
        
        // json to obj
        var obj = JsonConvert.DeserializeObject<List<TechnologyDataAccessModel>>(json);
        return obj;

    }

    public TechnologyDataAccessModel? GetTechnologyByGuid(Guid guid)
    {
        throw new NotImplementedException();
    }

    public TechnologyDataAccessModel? GetTechnologyByName(string name)
    {
        throw new NotImplementedException();
    }

    public List<TechnologyDataAccessModel?> SearchTechnologies(string text)
    {
        throw new NotImplementedException();
    }

    public TechnologyDataAccessModel? AddTechnology(TechnologyDataAccessModel technology)
    {
        //obj to json
        var json = JsonConvert.SerializeObject(technology);
        
        // json to obj
        var obj = JsonConvert.DeserializeObject<Technology>(json);

        var result = _publicUserUnity.Technologies.Add(obj);
        _publicUserUnity.Save();
        
        // obj to json
        json = JsonConvert.SerializeObject(result);
        
        // json to obj
        technology = JsonConvert.DeserializeObject<TechnologyDataAccessModel>(json);
        return technology;
    }

    public TechnologyDataAccessModel? UpdateTechnology(TechnologyDataAccessModel technology)
    {
        throw new NotImplementedException();
    }

    public bool DeleteTechnology(TechnologyDataAccessModel technology)
    {
        throw new NotImplementedException();
    }

    public bool DeleteTechnologyByGuid(Guid guid)
    {
        throw new NotImplementedException();
    }
}