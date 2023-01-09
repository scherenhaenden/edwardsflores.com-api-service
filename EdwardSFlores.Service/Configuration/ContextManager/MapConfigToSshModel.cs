using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.Service.Configuration.Models;

namespace EdwardSFlores.Service.Configuration.ContextManager;

public class MapConfigToSshModel
{
    
    public DbContextManagementModel Map(ConfigurationOfApplication configurationOfApplication)
    {
        
        var dbContextManagementModel = new DbContextManagementModel()
        {
            
            DbConnectionString = configurationOfApplication.DataAccess.DataBases.Global[0].ConnectionString,
        };
        
        if (configurationOfApplication?.TunnelingConfig != null)
        {
            var tunnelingModel = new TunnelingModel()
            {
                Localhost = configurationOfApplication.TunnelingConfig.PortForwardConfig.Host,
                LocalPorts = configurationOfApplication.TunnelingConfig.PortForwardConfig.BoundLocalPorts,
                //LocalPorts = new int []{ 5000, 5001, 5002},
                ForeignHost = configurationOfApplication.TunnelingConfig.SSHConfig.Host,
                ForeignPort = configurationOfApplication.TunnelingConfig.PortForwardConfig.Port,
                User = configurationOfApplication.TunnelingConfig.SSHConfig.User,
                Password = configurationOfApplication.TunnelingConfig.SSHConfig.Password,
                ProtocolPort = configurationOfApplication.TunnelingConfig.SSHConfig.Port,
            
            };

            dbContextManagementModel.TunnelingModel = tunnelingModel;
        }

        return dbContextManagementModel;
    }
}