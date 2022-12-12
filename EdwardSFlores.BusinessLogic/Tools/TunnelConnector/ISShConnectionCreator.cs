namespace EdwardSFlores.BusinessLogic.Tools.TunnelConnector;

public interface ISShConnectionCreator
{
    
}


public class SSHTunnelConnector : ISShConnectionCreator
{


    /*  public object CreateConnection()
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
    }*/
    
}