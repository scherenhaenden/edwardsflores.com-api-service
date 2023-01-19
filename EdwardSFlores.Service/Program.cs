using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.Service.ApiConfiguration.ServicesRegistration;
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

var registrationCarrier = new RegistrationCarrier();
registrationCarrier.Register(builder.Services);


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