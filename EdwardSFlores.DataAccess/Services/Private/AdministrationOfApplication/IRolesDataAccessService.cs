namespace EdwardSFlores.DataAccess.Services.Private.AdministrationOfApplication;

public interface IRolesDataAccessService
{

    // Get all roles with pagination
    List<RoleDataAccessModel> GetRoles(int page, int pageSize);
    
    // Get role by guids
    RoleDataAccessModel? GetRoleByGuid(Guid guid);
    
    // Get role by name
    RoleDataAccessModel? GetRoleByName(string name);
    
    // Get role list by list of guids
    List<RoleDataAccessModel> GetRoleListByGuids(List<Guid> guids);
    
    // Update role
    RoleDataAccessModel UpdateRole(RoleDataAccessModel role);
    
    // Delete role
    void DeleteRole(RoleDataAccessModel role);
    
    // Add role
    RoleDataAccessModel AddRole(RoleDataAccessModel role);
}