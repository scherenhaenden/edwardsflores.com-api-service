using EdwardSFlores.Service.Models;

namespace EdwardSFlores.Service.Chaos;

public interface IJwtManagementService
{
    public string CreateToken(JwtCreatorModelV1 jwtCreatorModelV1);
    
    public string CreateToken(JwtCreatorModelV2 jwtCreatorModelV2);

    public Guid? ValidateToken(string token, string keyRaw);
    
    public void SetTokenIntoCookie(string token);
    
    public string GetTokenFromCookie();
    
    public void RemoveTokenFromCookie();
    
    public void SetTokenIntoHeader(string token);
    
    public string GetTokenFromHeader();
    
    public void RevokeToken(string token);
    
    public void RevokeAllUserTokens(Guid userId);
    
    public void SetTokenAsUsed(string token);
    
    public void SetAllUserTokensAsUsed(Guid userId);
    
    public void SetTokenAsRevoked(string token);
    
    public void SetAllUserTokensAsRevoked(Guid userId);
    
    public void SetTokenAsExpired(string token);
    
    public void SetAllUserTokensAsExpired(Guid userId);
    
    public void SetTokenAsNotUsed(string token);
    
}