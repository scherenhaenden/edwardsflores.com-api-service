using System.Diagnostics;
using EdwardSFlores.Service.Configuration.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EdwardSFlores.Service.Configuration.Core;

public class ConfigurationLoad:IConfigurationLoad
{
    
    public ConfigurationOfApplication LoadAndGetConfiguration()
    {
        /*var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var configurationOfApplication = new ConfigurationOfApplication();
        configuration.Bind(configurationOfApplication);

        return configurationOfApplication;*/
        // get current directory
        var currentDirectory = Directory.GetCurrentDirectory();
        Debug.Print("Current Directory: " + currentDirectory);
        
        
        // get configuration file
        var configurationFile = Path.Combine(currentDirectory + "/publish", $"appsettings.json");
        
        // check if configuration file exists
        if (!File.Exists(configurationFile))
        {
            throw new FileNotFoundException($"Configuration file {configurationFile} not found");
        }
        
        // read configuration file
        var configurationFileContent = File.ReadAllText(configurationFile);
        
        var parsedObject = JObject.Parse(configurationFileContent);
        
        var popupJson = parsedObject["ConfigurationOfApplication"].ToString();
        
        // parse json to object
        var configurationOfApplication = JsonConvert.DeserializeObject<ConfigurationOfApplication>(
            popupJson);

        return configurationOfApplication;

    }

    private string GetNameOfConfigurationFile(string environment)
    {
        var configurationFile = "appsettings.json";
        if (!string.IsNullOrEmpty(environment))
        {
            configurationFile = $"appsettings.{environment}.json";
        }

        return configurationFile;
    }
    
    private string GetPathOfConfigurationFile(string currentDirectory, string configurationFile)
    {
        var configurationFilePath = Path.Combine(currentDirectory, configurationFile);
        if (!File.Exists(configurationFilePath))
        {
            configurationFilePath = Path.Combine(currentDirectory + "/publish", configurationFile);
        }

        return configurationFilePath;
    }
    

    public ConfigurationOfApplication LoadAndGetConfiguration(string environment)
    {
        // get current directory
        var currentDirectory = Directory.GetCurrentDirectory();

        var fileName = GetNameOfConfigurationFile(environment);
        
        // get configuration file
        var configurationFile = GetPathOfConfigurationFile(currentDirectory, fileName);
        
        // check if configuration file exists
        if (!File.Exists(configurationFile))
        {
            // print in console log
            Console.WriteLine($"Configuration file {configurationFile} not found");
            
            return LoadAndGetConfiguration();
            //throw new FileNotFoundException($"Configuration file {configurationFile} not found");
        }
        
        // read configuration file
        var configurationFileContent = File.ReadAllText(configurationFile);
        
        var parsedObject = JObject.Parse(configurationFileContent);
        
        var popupJson = parsedObject["ConfigurationOfApplication"].ToString();
        
        // parse json to object
        var configurationOfApplication = JsonConvert.DeserializeObject<ConfigurationOfApplication>(
            popupJson);

        return configurationOfApplication;
    }
}