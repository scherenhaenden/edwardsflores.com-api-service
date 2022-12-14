using System.Configuration;
using System.Diagnostics;
using EdwardSFlores.BusinessLogic.Services;
using EdwardSFlores.BusinessLogic.Services.Login;
using EdwardSFlores.BusinessLogic.Services.SingUp;
using EdwardSFlores.BusinessLogic.Tools;
using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Persistence.Configuration;
using EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Login;
using EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;
using EdwardSFlores.DataAccess.Database.Persistence.Unities;
using EdwardSFlores.DataAccess.Services.SingUp;
using EdwardSFlores.DataAccess.Services.Users;
using EdwardSFlores.Service.Configuration.ContextManager;
//using EdwardSFlores.Service.Configuration.ContextManager;
using EdwardSFlores.Service.Configuration.Core;
using EdwardSFlores.Service.Configuration.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
//builder.Services.AddSingleton<IDataContextManager>(provider  => new DataContextManagerLocal(result));
builder.Services.AddSingleton<IDataContextManager>(provider  => new DataContextManagerSsh(result));

// Add mysql context
/*builder.Services.AddDbContext<DbContextEdward>(options =>
    options.UseMySQL(database.ConnectionString));*/



builder.Services.AddScoped<ILogicDataAccessDatabaseRepositoryLogin, LogicDataAccessDatabaseGenericRepositoryLogin>();


// Add service injection for the unity of work
//builder.Services.AddScoped<IGenericUnitOfWork, GenericGenericUnitOfWork>();

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<ILoginBusinessLogic, LoginBusinessLogic>();
builder.Services.AddScoped<ISingUpDataAccess, SingUpDataAccess>();
builder.Services.AddScoped<ISingUpServiceBusinessLogic, SingUpServiceBusinessLogic>();


builder.Services.AddScoped<IUsersDataAccessDatabaseRepository, UsersDataAccessDatabaseRepository>();
builder.Services.AddScoped<IUsersDataAccessService, UsersDataAccessService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
// TODO: think about this
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();