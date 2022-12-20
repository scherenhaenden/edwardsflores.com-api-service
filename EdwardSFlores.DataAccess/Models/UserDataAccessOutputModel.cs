namespace EdwardSFlores.DataAccess.Services.Public.Login;

public class UserDataAccessOutputModel
{
    public Guid Guid { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public List<UserRoleOutputModel> UserRoles { get; set; }
}