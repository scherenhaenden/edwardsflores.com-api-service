using EdwardSFlores.Service.Configuration.Models;

namespace EdwardSFlores.Service.Configuration.Core;

public interface IConfigurationLoad
{
    ConfigurationOfApplication LoadAndGetConfiguration();
    
    ConfigurationOfApplication LoadAndGetConfiguration(string environment);
}