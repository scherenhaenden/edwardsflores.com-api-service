using EdwardSFlores.BusinessLogic.Models;
using EdwardSFlores.DataAccess.Models;
using EdwardSFlores.DataAccess.Services.Private.AdministrationOfApplication;
using EdwardSFlores.DataAccess.Services.Public.Jobs;
using EdwardSFlores.DataAccess.Services.Public.Technologies;
using Newtonsoft.Json;

namespace EdwardSFlores.BusinessLogic.Services.Technologies;

public interface ITechnologyBusiness
{
    // get all technologies
    List<TechnologyBusinessModel> GetTechnologies();
    
    // Add technology
    TechnologyBusinessModel AddTechnology(TechnologyBusinessModel technology);
    
    // Update technology
    TechnologyBusinessModel UpdateTechnology(TechnologyBusinessModel technology);
    
    // Delete technology by guid
    bool DeleteTechnology(Guid id);
    
    
}

public class TechnologyBusiness : ITechnologyBusiness
{
    private readonly ITechnologiesDataAccessService _technologiesDataAccessService;
    

    public TechnologyBusiness(ITechnologiesDataAccessService technologiesDataAccessService)
    {
        _technologiesDataAccessService = technologiesDataAccessService;
        
    }
    
    public List<TechnologyBusinessModel> GetTechnologies()
    {
        //var roles = _rolesDataAccessService.GetRoles();
        //return roles.MapObjToObj<List<RoleBusinessModel>>();
        var allTechnologies = _technologiesDataAccessService.GetAllTechnologies();

        return allTechnologies.MapObjToObj<List<TechnologyBusinessModel>>();
    }

    public TechnologyBusinessModel AddTechnology(TechnologyBusinessModel technology)
    {
        var obj2 = technology.MapObjToObj<TechnologyDataAccessModel>();

        var result = _technologiesDataAccessService.AddTechnology(obj2);

        technology = result.MapObjToObj<TechnologyBusinessModel>();

        return technology;
        
    }

    public TechnologyBusinessModel UpdateTechnology(TechnologyBusinessModel technology)
    {
        var obj2 = technology.MapObjToObj<TechnologyDataAccessModel>();

        var result = _technologiesDataAccessService.UpdateTechnology(obj2);

        technology = result.MapObjToObj<TechnologyBusinessModel>();

        return technology;
    }

    public bool DeleteTechnology(Guid id)
    {
        return _technologiesDataAccessService.DeleteTechnologyByGuid(id);
    }
}

//