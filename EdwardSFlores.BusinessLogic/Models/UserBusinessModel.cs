namespace EdwardSFlores.BusinessLogic.Services.Administration.Roles;

public class UserBusinessModel : BaseBusinessModel
{
    public Guid Guid { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public List<RoleBusinessModel> UserRoles { get; set; }

}