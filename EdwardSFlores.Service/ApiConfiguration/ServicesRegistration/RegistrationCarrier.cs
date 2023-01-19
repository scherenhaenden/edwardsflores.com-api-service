using EdwardSFlores.BusinessLogic.Services.Administration.Roles;
using EdwardSFlores.BusinessLogic.Services.Login;
using EdwardSFlores.BusinessLogic.Services.SingUp;
using EdwardSFlores.BusinessLogic.Services.Technologies;
using EdwardSFlores.BusinessLogic.Services.Users;
using EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;
using EdwardSFlores.DataAccess.Database.Security;
using EdwardSFlores.DataAccess.Services.Private.AdministrationOfApplication;
using EdwardSFlores.DataAccess.Services.Public.Technologies;
using EdwardSFlores.DataAccess.Services.Public.Users;
using EdwardSFlores.DataAccess.Services.SingUp;

namespace EdwardSFlores.Service.ApiConfiguration.ServicesRegistration;

public class RegistrationCarrier
{
    public void Register(IServiceCollection services, IConfiguration? configuration = null)
    {
        services.AddScoped<IPasswordHasher, HasherV3>();
        services.AddScoped<ILoginBusinessLogic, LoginBusinessLogic>();
        services.AddScoped<ISingUpDataAccess, SingUpDataAccess>();
        services.AddScoped<ISingUpServiceBusinessLogic, SingUpServiceBusinessLogic>();


        services.AddScoped<IUsersDataAccessDatabaseRepository, UsersDataAccessDatabaseRepository>();
        services.AddScoped<IUsersDataAccessService, UsersDataAccessService>();
        services.AddScoped<IUsersBusinessLogic, UsersBusinessLogic>();

        services.AddScoped<ITechnologiesDataAccessDatabase, TechnologiesDataAccessDatabase>();
        services.AddScoped<ITechnologiesDataAccessService, TechnologiesDataAccessService>();
        services.AddScoped<ITechnologyBusiness, TechnologyBusiness>();

        services.AddScoped<IRolesDataAccessDatabase, RolesDataAccessDatabase>();
        services.AddScoped<IRolesDataAccessService, RolesDataAccessService>();
        services.AddScoped<IRolesBusinessLogic, RolesBusinessLogic>();



        services.AddScoped<IJobsStationsDataAccessDatabase, JobsStationsDataAccessDatabase>();
        services.AddScoped<IJobsStationsAdministrationDataAccess, JobsStationsAdministrationDataAccess>();

        services.AddScoped<IJobsStationsBusinessService, JobsStationsBusinessService>();
        
        
        /*services.AddControllers();
        services.AddDbContext<Context>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "EdwardSFlores.Service.ApiConfiguration", Version = "v1" });
        });*/
    }
}