using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Persistence.Unities.ServiceUnities;
using Newtonsoft.Json;

namespace EdwardSFlores.DataAccess.Services.Private.AdministrationOfApplication;

public static class RoleDataAccessModelMapper 
{
    public static RoleDataAccessModel MapToRoleDataAccessModel(this Role roleServiceModel)
    {
        /*return new RoleDataAccessModel
        {
            Guid = roleServiceModel.Guid,
            Name = roleServiceModel.Name,
            Description = roleServiceModel.Description,
            CreatedAt = roleServiceModel.CreatedAt,
            /*NormalizedName = roleServiceModel.NormalizedName,
            ConcurrencyStamp = roleServiceModel.ConcurrencyStamp,
            Description = roleServiceModel.Description,
            CreatedAt = roleServiceModel.CreatedAt,
            UpdatedAt = roleServiceModel.UpdatedAt,
            DeletedAt = roleServiceModel.DeletedAt,
            IsDeleted = roleServiceModel.IsDeleted* /
        };*/
        
        // map via json
        // object to json

        return roleServiceModel.MapObjToObj<RoleDataAccessModel>();
    }
    
    public static Role MapToRoleServiceModel(this RoleDataAccessModel roleDataAccessModel)
    {
        /*return new Role
        {
            Guid = roleDataAccessModel.Guid,
            Name = roleDataAccessModel.Name,
            Description = roleDataAccessModel.Description,
            CreatedAt = roleDataAccessModel.CreatedAt,
            /*NormalizedName = roleDataAccessModel.NormalizedName,
            ConcurrencyStamp = roleDataAccessModel.ConcurrencyStamp,
            Description = roleDataAccessModel.Description,
            CreatedAt = roleDataAccessModel.CreatedAt,
            UpdatedAt = roleDataAccessModel.UpdatedAt,
            DeletedAt = roleDataAccessModel.DeletedAt,
            IsDeleted = roleDataAccessModel.IsDeleted* /
        };*/
        
        // map via json
        // object to json
        var json = JsonConvert.SerializeObject(roleDataAccessModel);
        
        // json to object
        var roleServiceModel = JsonConvert.DeserializeObject<Role>(json);
        return roleServiceModel;
    }

}


public class RolesDataAccessService: IRolesDataAccessService
{
    private readonly IPublicUserUnity _publicUserUnity;

    public RolesDataAccessService(IDataContextManager dataContextManager)
    {
        _publicUserUnity = new PublicUserUnity(dataContextManager);
    }


    public List<RoleDataAccessModel>? GetRoles(int page, int pageSize)
    {
        var roles = _publicUserUnity.Role.GetAll()?.ToList();
        
        return roles.MapObjToObj<List<RoleDataAccessModel>>();
    }

    public RoleDataAccessModel? GetRoleByGuid(Guid guid)
    {
        var role = _publicUserUnity.Role.GetByGuid(guid);
        return role.MapObjToObj<RoleDataAccessModel>();
    }

    public RoleDataAccessModel? GetRoleByName(string name)
    {
        var role = _publicUserUnity.Role.GetRoleByName(name);
        return role.MapObjToObj<RoleDataAccessModel>();
    }

    public List<RoleDataAccessModel> GetRoleListByGuids(List<Guid> guids)
    {
        var roles = _publicUserUnity.Role.GetRoleListByGuids(guids);
        return roles.MapObjToObj<List<RoleDataAccessModel>>();
    }

    public RoleDataAccessModel UpdateRole(RoleDataAccessModel role)
    {
        var roleServiceModel = role.MapObjToObj<Role>();
        var updatedRole = _publicUserUnity.Role.Update(roleServiceModel);
        _publicUserUnity.Save();
        return updatedRole.MapObjToObj<RoleDataAccessModel>();
    }

    public void DeleteRole(RoleDataAccessModel role)
    {
        var roleServiceModel = role.MapObjToObj<Role>();
        _publicUserUnity.Save();
        _publicUserUnity.Role.Remove(roleServiceModel);
    }

    public RoleDataAccessModel AddRole(RoleDataAccessModel role)
    {
        var roleServiceModel = role.MapObjToObj<Role>();
        var addedRole = _publicUserUnity.Role.Add(roleServiceModel);
        _publicUserUnity.Save();
        return addedRole.MapObjToObj<RoleDataAccessModel>();
    }
}