namespace EdwardSFlores.DataAccess.Services.Login;

public class UserLoginOutputModel
{
    public Guid Guid { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public List<UserRoleOutputModel> UserRoles { get; set; }
}