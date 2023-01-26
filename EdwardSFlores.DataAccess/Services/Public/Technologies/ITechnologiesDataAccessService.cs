using EdwardSFlores.DataAccess.Models;

namespace EdwardSFlores.DataAccess.Services.Public.Technologies;

public interface ITechnologiesDataAccessService
{
    // get all technologies
    List<TechnologyDataAccessModel?> GetAllTechnologies();
    
    // get technology by guid
    TechnologyDataAccessModel? GetTechnologyByGuid(Guid guid);
    
    // get technology by name
    TechnologyDataAccessModel? GetTechnologyByName(string name);
    
    // search text in description of technologies
    List<TechnologyDataAccessModel?> SearchTechnologies(string text);
    
    // add technology
    TechnologyDataAccessModel? AddTechnology(TechnologyDataAccessModel technology);
    
    // update technology
    TechnologyDataAccessModel? UpdateTechnology(TechnologyDataAccessModel technology);
    
    // delete technology
    bool DeleteTechnology(TechnologyDataAccessModel technology);
    bool DeleteTechnologyByGuid(Guid guid);
}