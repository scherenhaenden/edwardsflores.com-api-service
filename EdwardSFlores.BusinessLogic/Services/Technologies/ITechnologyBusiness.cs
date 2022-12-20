using EdwardSFlores.DataAccess.Models;
using EdwardSFlores.DataAccess.Services.Public.Jobs;
using EdwardSFlores.DataAccess.Services.Public.Technologies;
using Newtonsoft.Json;

namespace EdwardSFlores.BusinessLogic.Services.Technologies;

public interface ITechnologyBusiness
{
    // get all technologies
    List<TechnologyBusinessModelBusiness> GetTechnologies();
    
    // Add technology
    TechnologyBusinessModelBusiness AddTechnology(TechnologyBusinessModelBusiness technology);
    
}

public class TechnologyBusiness : ITechnologyBusiness
{
    private readonly ITechnologiesDataAccessService _technologiesDataAccessService;
    

    public TechnologyBusiness(ITechnologiesDataAccessService technologiesDataAccessService)
    {
        _technologiesDataAccessService = technologiesDataAccessService;
        
    }
    
    public List<TechnologyBusinessModelBusiness> GetTechnologies()
    {
        
        var obj = _technologiesDataAccessService.GetAllTechnologies();
        // obj to json
        var json = JsonConvert.SerializeObject(obj);
        
        // json to obj
        var obj2 = JsonConvert.DeserializeObject<List<TechnologyBusinessModelBusiness>>(json);
        
        return obj2;
        
        
    }

    public TechnologyBusinessModelBusiness AddTechnology(TechnologyBusinessModelBusiness technology)
    {
        // obj to json
        var json = JsonConvert.SerializeObject(technology);
        
        // json to obj
        var obj2 = JsonConvert.DeserializeObject<TechnologyDataAccessModel>(json);
        
        var result = _technologiesDataAccessService.AddTechnology(obj2);
        
        // obj to json
        var json2 = JsonConvert.SerializeObject(result);
        
        // json to obj
        var obj3 = JsonConvert.DeserializeObject<TechnologyBusinessModelBusiness>(json2);
        
        return obj3;
        
    }
}

//

public class TechnologyBusinessModelBusiness : BaseModelBusinessObject
{
    public string Name { get; set; } = null!;
    
    public string? Description { get; set; }
    
    public string? Image { get; set; }
    
    public string? Url { get; set; }
    
    public int? ExperienceLevel { get; set; }
}

public class BaseModelBusinessObject
{
    public Guid Guid { get; set; }
    public DateTime InsertedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsActive { get; set; } 
}