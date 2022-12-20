using EdwardSFlores.DataAccess.Services.Private.AdministrationOfApplication;

namespace EdwardSFlores.BusinessLogic.Services.Administration.Roles;

public interface IRolesBusinessLogic
{
    RoleBusinessModel AddRole(RoleBusinessModel role);

    List<RoleBusinessModel> GetRoles();
    
    // Get role by guid
    RoleBusinessModel GetRole(Guid id);
    
    // Get role by name
    
    RoleBusinessModel GetRole(string name);
    
    // Update role
    RoleBusinessModel UpdateRole(RoleBusinessModel role);
    
}

public class RolesBusinessLogic: IRolesBusinessLogic
{
    private readonly IRolesDataAccessService _rolesDataAccessService;

    public RolesBusinessLogic(IRolesDataAccessService rolesDataAccessService)
    {
        _rolesDataAccessService = rolesDataAccessService;
    }
    
    // Add roles business logic here
    // Create method to add role
    public RoleBusinessModel AddRole(RoleBusinessModel role)
    {
        
        var roleServiceModel = role.MapObjToObj<RoleDataAccessModel>();
        roleServiceModel = _rolesDataAccessService.AddRole(roleServiceModel);
        return roleServiceModel.MapObjToObj<RoleBusinessModel>();
    }
    
    // Get roles
    public List<RoleBusinessModel> GetRoles()
    {
        var roles = _rolesDataAccessService.GetRoles();
        return roles.MapObjToObj<List<RoleBusinessModel>>();
    }

    public RoleBusinessModel GetRole(Guid id)
    {
        var role = _rolesDataAccessService.GetRoleByGuid(id);
        return role.MapObjToObj<RoleBusinessModel>();
    }

    public RoleBusinessModel GetRole(string name)
    {
        var role = _rolesDataAccessService.GetRoleByName(name);
        return role.MapObjToObj<RoleBusinessModel>();
    }

    public RoleBusinessModel UpdateRole(RoleBusinessModel role)
    {
        var roleDataAccessModel = role.MapObjToObj<RoleDataAccessModel>();
        roleDataAccessModel = _rolesDataAccessService.UpdateRole(roleDataAccessModel);
        return roleDataAccessModel.MapObjToObj<RoleBusinessModel>();
    }
}