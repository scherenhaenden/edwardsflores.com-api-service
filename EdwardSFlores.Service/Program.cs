using EdwardSFlores.BusinessLogic.Services.Administration.Roles;
using EdwardSFlores.BusinessLogic.Services.Login;
using EdwardSFlores.BusinessLogic.Services.SingUp;
using EdwardSFlores.BusinessLogic.Services.Technologies;
using EdwardSFlores.BusinessLogic.Services.Users;
using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;
using EdwardSFlores.DataAccess.Database.Security;
using EdwardSFlores.DataAccess.Services.Private.AdministrationOfApplication;
using EdwardSFlores.DataAccess.Services.Public.Jobs;
using EdwardSFlores.DataAccess.Services.Public.Technologies;
using EdwardSFlores.DataAccess.Services.Public.Users;
using EdwardSFlores.DataAccess.Services.SingUp;
using EdwardSFlores.Service.Configuration.ContextManager;
//using EdwardSFlores.Service.Configuration.ContextManager;
using EdwardSFlores.Service.Configuration.Core;
using EdwardSFlores.Service.Configuration.Models;
using EdwardSFlores.Service.Middlewares.Cors;
using EdwardSFlores.Service.Services.Security.Jwt;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo {
        Title = "JWTToken_Auth_API", Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// load configuration
/*
var configuration = builder.Configuration;
var localSettings = configuration.GetSection("ConfigurationOfApplication").Get<ConfigurationOfApplication>();*/

// get the database with contextname "global" from the configuration

// load configuration settings
var configuration = builder.Configuration;
var appSettingsSection = configuration.GetSection("ConfigurationOfApplication");

appSettingsSection.Bind(builder.Configuration);


IConfigurationLoad configurationLoader = new ConfigurationLoad();

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var localSettings  = configurationLoader.LoadAndGetConfiguration(environment);
builder.Services.Configure<ConfigurationOfApplication>(appSettingsSection);
var database = localSettings.DataAccess.DataBases.Global.FirstOrDefault(x => x.ContextName == "unique");

//builder.Services.AddSingleton<IServiceCollectionProvider>(new ServiceCollectionProvider(builder.Services));
var result =new MapConfigToSshModel().Map(localSettings);



builder.Services.AddSingleton<IDataContextManager>(provider  => new DataContextManagerLocal(result));
//builder.Services.AddSingleton<IDataContextManager>(provider  => new DataContextManagerSsh(result));

// Add mysql context
/*builder.Services.AddDbContext<DbContextEdward>(options =>
    options.UseMySQL(database.ConnectionString));*/


// Add service injection for the unity of work
//builder.Services.AddScoped<IGenericUnitOfWork, GenericGenericUnitOfWork>();



builder.Services.AddScoped<IPasswordHasher, HasherV3>();
builder.Services.AddScoped<ILoginBusinessLogic, LoginBusinessLogic>();
builder.Services.AddScoped<ISingUpDataAccess, SingUpDataAccess>();
builder.Services.AddScoped<ISingUpServiceBusinessLogic, SingUpServiceBusinessLogic>();


builder.Services.AddScoped<IUsersDataAccessDatabaseRepository, UsersDataAccessDatabaseRepository>();
builder.Services.AddScoped<IUsersDataAccessService, UsersDataAccessService>();
builder.Services.AddScoped<IUsersBusinessLogic, UsersBusinessLogic>();

builder.Services.AddScoped<ITechnologiesDataAccessDatabase, TechnologiesDataAccessDatabase>();
builder.Services.AddScoped<ITechnologiesDataAccessService, TechnologiesDataAccessService>();
builder.Services.AddScoped<ITechnologyBusiness, TechnologyBusiness>();

builder.Services.AddScoped<IRolesDataAccessDatabase, RolesDataAccessDatabase>();
builder.Services.AddScoped<IRolesDataAccessService, RolesDataAccessService>();
builder.Services.AddScoped<IRolesBusinessLogic, RolesBusinessLogic>();



builder.Services.AddScoped<IJobsStationsDataAccessDatabase, JobsStationsDataAccessDatabase>();
builder.Services.AddScoped<IJobsStationsAdministrationDataAccess, JobsStationsAdministrationDataAccess>();

builder.Services.AddScoped<IJobsStationsBusinessService, JobsStationsBusinessService>();
    

var app = builder.Build();

// TODO: think about this
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName.ToLower().Contains("development"))
{
    app.UseCors(builder => builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials()
    );
    app.UseDeveloperExceptionPage();
    app.UseCorsMiddleware();
}
else
{
    app.UseHttpsRedirection();
}

app.UseMiddleware<JwtMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();