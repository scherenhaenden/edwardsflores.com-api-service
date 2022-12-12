using EdwardSFlores.Service.Models;

namespace EdwardSFlores.Service.Chaos;

public interface IJwtGenerator
{
    string CreateToken(JwtCreatorModel jwtCreatorModel);
}