using EdwardSFlores.DataAccess.Database.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EdwardSFlores.Service.Services.Security.Jwt;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeViaJwtV1Attribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.Items["User"];
        if (user == null)
        {
            // not logged in
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}