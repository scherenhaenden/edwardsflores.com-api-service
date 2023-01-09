namespace EdwardSFlores.BusinessLogic.Services.Administration.Roles;

public interface IRolesBusinessLogic
{
    RoleBusinessModel AddRole(RoleBusinessModel role);

    // get roles with pagination
    List<RoleBusinessModel> GetRoles(int page, int pageSize);
    
    // Get role by guid
    RoleBusinessModel GetRole(Guid id);
    
    // Get role by name
    
    RoleBusinessModel GetRole(string name);
    
    // Update role
    RoleBusinessModel UpdateRole(RoleBusinessModel role);
    
}