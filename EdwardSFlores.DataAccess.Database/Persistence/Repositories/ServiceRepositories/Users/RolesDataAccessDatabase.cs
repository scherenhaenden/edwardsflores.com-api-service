using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Persistence.Configuration;

namespace EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;

public class RolesDataAccessDatabase : GenericRepository<Technology>, IRolesDataAccessDatabase
{
    private readonly DbContextEdward _dbContextEdward;
    private readonly IGenericUnitOfWork _genericUnitOfWork;
    
    public RolesDataAccessDatabase(IDataContextManager dataContextManager): base(dataContextManager.DbContextEdward)
    {
        _dbContextEdward = dataContextManager.DbContextEdward;
        _genericUnitOfWork = dataContextManager.GenericUnityOfWork;
    }

    public List<Role> GetRoles()
    {
        return _genericUnitOfWork.Role.GetAll().ToList();
    }

    public Role? GetRoleByGuid(Guid guid)
    {
        return _genericUnitOfWork.Role.GetByGuid(guid);
    }

    public Role? GetRoleByName(string name)
    {
        return _genericUnitOfWork.Role.Where(x=>x.Name == name).FirstOrDefault();
    }

    public List<Role> GetRoleListByGuids(List<Guid> guids)
    {
        return _genericUnitOfWork.Role.Where(x => guids.Contains(x.Guid)).ToList();
    }

    public Role UpdateRole(Role role)
    {
        _genericUnitOfWork.Role.Update(role);
        _genericUnitOfWork.Save();
        return role;
    }

    public void DeleteRole(Role role)
    {
        _genericUnitOfWork.Role.Remove(role);
        _genericUnitOfWork.Save();
    }

    public Role AddRole(Role role)
    {
        throw new NotImplementedException();
    }
}