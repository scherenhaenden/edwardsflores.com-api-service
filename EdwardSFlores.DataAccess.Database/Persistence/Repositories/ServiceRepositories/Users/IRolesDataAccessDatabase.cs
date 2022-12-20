using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Repositories;

namespace EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;

public interface IRolesDataAccessDatabase : IRepository<Technology>
{
    // Get all roles
    List<Role> GetRoles();
    
    // Get role by guids
    Role? GetRoleByGuid(Guid guid);
    
    // Get role by name
    Role? GetRoleByName(string name);
    
    // Get role list by list of guids
    List<Role> GetRoleListByGuids(List<Guid> guids);
    
    // Update role
    Role UpdateRole(Role role);
    
    // Delete role
    void DeleteRole(Role role);
    
    // Add role
    Role AddRole(Role role);
}