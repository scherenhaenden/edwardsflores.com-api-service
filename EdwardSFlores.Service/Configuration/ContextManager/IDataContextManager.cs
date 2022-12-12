using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Persistence.Configuration;
using EdwardSFlores.DataAccess.Database.Persistence.Unities;
using EdwardSFlores.Service.Configuration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TunnelConnector.Credentials;
using TunnelConnector.LoadBalancer;
using TunnelConnector.Protocls;

namespace EdwardSFlores.Service.Configuration.ContextManager;

public interface IDataContextManager
{
    IUnitOfWork UnitOfWork { get; }
}

public class DataContextManager : IDataContextManager
{
    private readonly ConfigurationOfApplication _appSettings;
    public IUnitOfWork UnitOfWork { get; private set; }
    private static ILoadBalancer _loadBalancer;

    public DataContextManager(IOptions<ConfigurationOfApplication> appSettings)
    {
        _appSettings = appSettings.Value;
        CreateUnitOfWork();
    }

    private void CreateUnitOfWork()
    {
        var loadBalancerConfiguration = new LoadBalancerConfiguration()
        {
            Localhost = _appSettings.TunnelingConfig.PortForwardConfig.Host,
            LocalPorts = _appSettings.TunnelingConfig.PortForwardConfig.BoundLocalPorts,
            //LocalPorts = new int []{ 5000, 5001, 5002},
            ForeignHost = _appSettings.TunnelingConfig.SSHConfig.Host,
            ForeignPort = _appSettings.TunnelingConfig.PortForwardConfig.Port,
            User = _appSettings.TunnelingConfig.SSHConfig.User,
            Password = _appSettings.TunnelingConfig.SSHConfig.Password,
            ProtocolPort = _appSettings.TunnelingConfig.SSHConfig.Port,
            CurrentProtocol = AvailableProtocols.Ssh
        };
        _loadBalancer = new LoadBalancer(loadBalancerConfiguration);
        
        int portReplace;
        try
        {
            portReplace = _loadBalancer.RunClientAndGetActivePort();
        }
        catch (Exception e)
        {
            portReplace = _loadBalancer.RunClientAndGetActivePort();
            //int r = rnd.Next(LocalPorts.ToList().Count);
            //portReplace = LocalPorts[r];
        }
            
              
        var connectionString = _appSettings.DataAccess.DataBases.Global[0].ConnectionString;
        connectionString = connectionString.Replace("Port=33060", $"Port={portReplace}");
        // init mysql   DbContextOptions<DbContextEdward> options
        var options = new DbContextOptionsBuilder<DbContextEdward>()
            .UseMySQL(connectionString);
        
        var context = new DbContextEdward(options.Options);
            
        
        
        UnitOfWork = new UnitOfWork(context);
    

    }
}