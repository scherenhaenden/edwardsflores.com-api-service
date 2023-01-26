using System.IdentityModel.Tokens.Jwt;
using System.Text;
using EdwardSFlores.BusinessLogic.Services.Users;
using EdwardSFlores.Service.Chaos;
using EdwardSFlores.Service.Configuration.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EdwardSFlores.Service.Services.Security.Jwt;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ConfigurationOfApplication _appSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<ConfigurationOfApplication> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context, IUsersBusinessLogic usersBusinessLogic)
    {
       
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
            attachUserToContext(context, usersBusinessLogic, token);

        await _next(context);
    }

    private void attachUserToContext(HttpContext context, IUsersBusinessLogic usersBusinessLogic, string token)
    {
        try
        {
            
            IJwtManagementService jwtManagementService = new JwtManagementService();
            var result = jwtManagementService.ValidateToken(token, _appSettings.Temporal.JwtSecret);
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Temporal.JwtSecret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "nameid").Value);

            // attach user to context on successful jwt validation
            context.Items["User"] = usersBusinessLogic.GetUserById(userId);
        }
        catch(Exception e)
        {
            var message = e.Message;
            // do nothing if jwt validation fails
            // user is not attached to context so request won't have access to secure routes
        }
    }
}

