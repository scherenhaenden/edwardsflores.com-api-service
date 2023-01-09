using EdwardSFlores.Service.Configuration.Models;

namespace EdwardSFlores.Service.Middlewares.Cors
{
    public static class CorsMiddlewareExtensions
    {
        public static IApplicationBuilder UseCorsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CorsMiddleware>();
        }
    }
    
    /*public static class DataContextManagerExtensions
    {
        public static IApplicationBuilder UseDataContextManagerV1Middleware(this IApplicationBuilder builder, ConfigurationOfApplication configuration)
        {
            return builder.UseMiddleware<DataContextManagerV1Middleware>(configuration);
        }
        
    }*/
}