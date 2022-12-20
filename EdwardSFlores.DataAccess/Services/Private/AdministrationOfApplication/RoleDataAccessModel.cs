using EdwardSFlores.DataAccess.Models;

namespace EdwardSFlores.DataAccess.Services.Private.AdministrationOfApplication;

public class RoleDataAccessModel: BaseModelObject
{
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public virtual List<UserDataAccessOutputModel> Users { get; set; }
}