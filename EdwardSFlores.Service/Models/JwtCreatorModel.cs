namespace EdwardSFlores.Service.Models;

public class JwtCreatorModel
{
    public JwtCreatorModel(string userId, string userName, string secret, string issuer, string audience, int expireMinutes, string[]? claims = null, string[]? roles = null)
    {
        UserId = userId;
        UserName = userName;
        Secret = secret;
        Issuer = issuer;
        Audience = audience;
        ExpireMinutes = expireMinutes;
        Claims = claims;
        Roles = roles;
    }

    public string UserId { get; private set; }
    public string UserName { get; private set; }
    public string Secret { get; private set; }
    public string Issuer { get; private set; }
    public string Audience { get; private set; }
    public int ExpireMinutes { get; private set; }
    public string[]? Claims { get; private set; }
    public string[]? Roles { get; private set; }
}