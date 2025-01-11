namespace EdwardSFlores.BusinessLogic.Services.Login;

public class UserLoginBusinessOut
{
    public Guid Guid { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public bool IsAuthenticated { get; set; }
}