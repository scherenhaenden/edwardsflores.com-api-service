namespace EdwardSFlores.BusinessLogic.Services.Administration.Roles;

public class RoleBusinessModel: BaseBusinessModelObject
{
    
    
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public virtual List<UserBusinessModel> Users { get; set; }
    
    
}