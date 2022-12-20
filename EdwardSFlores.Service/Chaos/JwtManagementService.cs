
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EdwardSFlores.Service.Models;
using Microsoft.IdentityModel.Tokens;

namespace EdwardSFlores.Service.Chaos;

public class JwtManagement: IJwtManagement
{
    public string CreateToken(JwtCreatorModel jwtCreatorModel)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.NameId, jwtCreatorModel.UserId),
            new Claim(JwtRegisteredClaimNames.UniqueName, jwtCreatorModel.UserName),
            new Claim(JwtRegisteredClaimNames.Iss, jwtCreatorModel.Issuer),
            new Claim(JwtRegisteredClaimNames.Aud, jwtCreatorModel.Audience),
            new Claim(JwtRegisteredClaimNames.Exp, DateTime.UtcNow.AddMinutes(jwtCreatorModel.ExpireMinutes).ToString(CultureInfo.InvariantCulture))
            
        };
        
        claims.AddRange(jwtCreatorModel.Claims?.Select(claim => new Claim(claim, claim)));
        claims.AddRange(jwtCreatorModel.Roles?.Select(role => new Claim(ClaimTypes.Role, role)));
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret key"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds
        };
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
        
        
    }

    public Guid? ValidateToken(string token)
    {
        throw new NotImplementedException();
    }


    /*private string generateJwtToken(string email, AppUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret key"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }*/

   
}