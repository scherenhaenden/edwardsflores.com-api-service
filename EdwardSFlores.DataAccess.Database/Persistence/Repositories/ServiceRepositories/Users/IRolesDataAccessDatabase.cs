using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Repositories;

namespace EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;

public interface IRolesDataAccessDatabase : IRepository<Role>
{
    // Get all roles
    List<Role> GetRoles();
    
    // Get role by guids
    Role? GetRoleByGuid(Guid guid);
    
    // Get role by name
    Role? GetRoleByName(string name);
    
    // Get role list by list of guids
    List<Role> GetRoleListByGuids(List<Guid> guids);
}