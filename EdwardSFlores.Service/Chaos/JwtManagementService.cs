
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EdwardSFlores.Service.Models;
using Microsoft.IdentityModel.Tokens;

namespace EdwardSFlores.Service.Chaos;

public class JwtManagementService: IJwtManagementService
{
    
    public string CreateToken(JwtCreatorModelV2 jwtCreatorModelV2)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.NameId, jwtCreatorModelV2.UserId),
            new Claim(JwtRegisteredClaimNames.UniqueName, jwtCreatorModelV2.UserName),
            new Claim(JwtRegisteredClaimNames.Iss, jwtCreatorModelV2.Issuer),
            new Claim(JwtRegisteredClaimNames.Aud, jwtCreatorModelV2.Audience),
            new Claim(JwtRegisteredClaimNames.Exp, DateTime.UtcNow.AddMinutes(jwtCreatorModelV2.ExpireMinutes).ToString(CultureInfo.InvariantCulture))
            
        };

        foreach (var VARIABLE in jwtCreatorModelV2.Claims)
        {
            claims.Add(new Claim(VARIABLE.Key, VARIABLE.Value));

        }
        
        foreach (var VARIABLE in jwtCreatorModelV2.Roles)
        {
            claims.Add(new Claim(VARIABLE.Key, VARIABLE.Value));

        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtCreatorModelV2.Secret));
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
    
    
    
    public string CreateToken(JwtCreatorModelV1 jwtCreatorModelV1)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.NameId, jwtCreatorModelV1.UserId),
            new Claim(JwtRegisteredClaimNames.UniqueName, jwtCreatorModelV1.UserName),
            new Claim(JwtRegisteredClaimNames.Iss, jwtCreatorModelV1.Issuer),
            new Claim(JwtRegisteredClaimNames.Aud, jwtCreatorModelV1.Audience),
            new Claim(JwtRegisteredClaimNames.Exp, DateTime.UtcNow.AddMinutes(jwtCreatorModelV1.ExpireMinutes).ToString(CultureInfo.InvariantCulture))
            
        };
        
        claims.AddRange(jwtCreatorModelV1.Claims?.Select(claim => new Claim(claim, claim)));
        claims.AddRange(jwtCreatorModelV1.Claims?.Select(claim => new Claim("token", claim)));
        claims.AddRange(jwtCreatorModelV1.Roles?.Select(role => new Claim(ClaimTypes.Role, role)));
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtCreatorModelV1.Secret));
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

    public Guid? ValidateToken(string token, string keyRaw)
    {
        // validate token
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(keyRaw);
        
        // craete SignatureValidator
        //var signatureValidator = new SignatureValidator(Encoding.UTF8.GetBytes(jwtCreatorModel.Secret));
        
        
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            //SignatureValidator = signatureValidator
            
        }, out var validatedToken);
        
        var jwtToken = (JwtSecurityToken)validatedToken;
        var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "nameid").Value);
        return userId;

    }

    public void SetTokenIntoCookie(string token)
    {
        throw new NotImplementedException();
    }

    public string GetTokenFromCookie()
    {
        throw new NotImplementedException();
    }

    public void RemoveTokenFromCookie()
    {
        throw new NotImplementedException();
    }

    public void SetTokenIntoHeader(string token)
    {
        throw new NotImplementedException();
    }

    public string GetTokenFromHeader()
    {
        throw new NotImplementedException();
    }

    public void RevokeToken(string token)
    {
        throw new NotImplementedException();
    }

    public void RevokeAllUserTokens(Guid userId)
    {
        throw new NotImplementedException();
    }

    public void SetTokenAsUsed(string token)
    {
        throw new NotImplementedException();
    }

    public void SetAllUserTokensAsUsed(Guid userId)
    {
        throw new NotImplementedException();
    }

    public void SetTokenAsRevoked(string token)
    {
        throw new NotImplementedException();
    }

    public void SetAllUserTokensAsRevoked(Guid userId)
    {
        throw new NotImplementedException();
    }

    public void SetTokenAsExpired(string token)
    {
        throw new NotImplementedException();
    }

    public void SetAllUserTokensAsExpired(Guid userId)
    {
        throw new NotImplementedException();
    }

    public void SetTokenAsNotUsed(string token)
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