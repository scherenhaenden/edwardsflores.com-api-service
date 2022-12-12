using EdwardSFlores.BusinessLogic.Services;
using EdwardSFlores.BusinessLogic.Services.Login;
using EdwardSFlores.BusinessLogic.Services.SingUp;
using EdwardSFlores.BusinessLogic.Tools;
using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Persistence.Configuration;
using EdwardSFlores.DataAccess.Database.Persistence.Unities;
using EdwardSFlores.DataAccess.Services.SingUp;
using EdwardSFlores.Service.Configuration.Core;
using EdwardSFlores.Service.Configuration.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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


IConfigurationLoad configurationLoader = new ConfigurationLoad();
var localSettings  = configurationLoader.LoadAndGetConfiguration("Development");
var database = localSettings.DataAccess.DataBases.Global.FirstOrDefault(x => x.ContextName == "unique");

// Add mysql context
builder.Services.AddDbContext<DbContextEdward>(options =>
    options.UseMySQL(database.ConnectionString));

// Add service injection for the unity of work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<ILoginBusinessLogic, LoginBusinessLogic>();
builder.Services.AddScoped<ISingUpDataAccess, SingUpDataAccess>();
builder.Services.AddScoped<ISingUpServiceBusinessLogic, SingUpServiceBusinessLogic>();

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