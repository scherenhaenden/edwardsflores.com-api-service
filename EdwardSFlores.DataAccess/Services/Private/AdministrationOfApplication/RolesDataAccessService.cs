using EdwardSFlores.DataAccess.Database.Persistence.Unities.ServiceUnities;

namespace EdwardSFlores.DataAccess.Services.Private.AdministrationOfApplication;

public class RolesDataAccessService: IRolesDataAccessService
{
    private readonly IPublicUserUnity _ipUserUnity;

    public RolesDataAccessService(IPublicUserUnity ipUserUnity)
    {
        _ipUserUnity = ipUserUnity;
    }


    public List<RoleDataAccessModel> GetRoles()
    {
        throw new NotImplementedException();
    }

    public RoleDataAccessModel? GetRoleByGuid(Guid guid)
    {
        throw new NotImplementedException();
    }

    public RoleDataAccessModel? GetRoleByName(string name)
    {
        throw new NotImplementedException();
    }

    public List<RoleDataAccessModel> GetRoleListByGuids(List<Guid> guids)
    {
        throw new NotImplementedException();
    }

    public RoleDataAccessModel UpdateRole(RoleDataAccessModel role)
    {
        throw new NotImplementedException();
    }

    public void DeleteRole(RoleDataAccessModel role)
    {
        throw new NotImplementedException();
    }

    public RoleDataAccessModel AddRole(RoleDataAccessModel role)
    {
        throw new NotImplementedException();
    }
}