using EdwardSFlores.DataAccess.Services.Private.AdministrationOfApplication;

namespace EdwardSFlores.DataAccess.Models;

public class UserDataAccessOutputModel: BaseModelObject
{
    public Guid Guid { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public List<RoleDataAccessModel> UserRoles { get; set; }
}