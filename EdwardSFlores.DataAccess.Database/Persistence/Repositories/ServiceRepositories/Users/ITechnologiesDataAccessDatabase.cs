using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Repositories;

namespace EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;

public interface ITechnologiesDataAccessDatabase : IRepository<Technology>
{
    // get all technologies
    List<Technology?> GetAllTechnologies();
    
    // get technology by guid
    Technology? GetTechnologyByGuid(Guid guid);
    
    // get technology by name
    Technology? GetTechnologyByName(string name);
    
    // search text in description of technologies
    List<Technology?> SearchTechnologies(string text);
    
    // add technology
    Technology? AddTechnology(Technology technology);
    
    // update technology
    Technology? UpdateTechnology(Technology technology);
    
    // delete technology
    bool DeleteTechnology(Technology technology);
    bool DeleteTechnologyByGuid(Guid guid);
}