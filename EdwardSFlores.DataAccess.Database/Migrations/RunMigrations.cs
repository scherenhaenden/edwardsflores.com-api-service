using EdwardSFlores.DataAccess.Database.Migrations._122022;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace EdwardSFlores.DataAccess.Database.Migrations;

public class RunMigrations
{
    public RunMigrations(string connection)
    {
        UpdateDatabase(CreateServices(connection));
    }
    
    private void UpdateDatabase(IServiceProvider serviceProvider)
    {
            
            
        using (var scope = serviceProvider.CreateScope())
        {
            // Instantiate the runner
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
            runner.Up(new AddTechnologyTable());
        }
    }
    
    private IServiceProvider CreateServices(string connection)
    {

        //var h= System.Reflection.Assembly.GetExecutingAssembly();

        return new ServiceCollection()// Add common FluentMigrator services
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                // Add SQLite support to FluentMigrator
                .AddMySql5()
                    
                // Set the connection string
                .WithGlobalConnectionString(connection)
                // Define the assembly containing the migrations
                //.ScanIn(typeof(UoWRepo.Migrations.AddNewColumnVersionOfNews).Assembly).For.Migrations()
                .ScanIn(System.Reflection.Assembly.GetExecutingAssembly()).For.Migrations()
            )
               
            // Build the service provider
            .BuildServiceProvider(false);
    }
}