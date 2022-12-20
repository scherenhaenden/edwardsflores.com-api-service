using EdwardSFlores.Service.Models;

namespace EdwardSFlores.Service.Chaos;

public interface IJwtManagement
{
    string CreateToken(JwtCreatorModel jwtCreatorModel);
    
    public Guid? ValidateToken(string token);
}