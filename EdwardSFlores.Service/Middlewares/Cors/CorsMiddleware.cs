using Microsoft.AspNetCore.Cors.Infrastructure;

namespace EdwardSFlores.Service.Middlewares.Cors
{
    public class CorsMiddleware
    {
        private readonly RequestDelegate _next;

        public CorsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            
            if (!httpContext.Request.Headers.ContainsKey(CorsConstants.Origin)) return _next(httpContext);

            httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:4200/");
            httpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            httpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, X-CSRF-Token, X-Requested-With, Accept, Accept-Version, Content-Length, Content-MD5, Date, X-Api-Version, X-File-Name");
            httpContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,PUT,PATCH,DELETE,OPTIONS, METHOD");
            return _next(httpContext);
        }
    }
}