namespace EdwardSFlores.Service.Configuration.Models;

public class ConfigurationOfApplication
{
    public DataAccess DataAccess { get; set; }
    
    public TemporalKeys Temporal { get; set; }
    
    public TunnelingConfig TunnelingConfig { get; set; } = null; 
    
}
public class TunnelingConfig
{
    public SSHConfig SSHConfig { get; set; } 
    public PortForwardConfig PortForwardConfig { get; set; } 
}

public class PortForwardConfig
{
    public string Host { get; set; }
        
    [Obsolete]
    public int BoundLocalPort { get; set; }
        
    public int[] BoundLocalPorts { get; set; } 
    public string ForeingHost { get; set; } 
    public int Port { get; set; } 
}

public class SSHConfig
{
    public string Host { get; set; } 
    public int Port { get; set; } 
    public string User { get; set; } 
    public string Password { get; set; } 
}
public class TemporalKeys
{
    public string JwtSecret { get; set; }
}

public class DataAccess
{
    public DataBases DataBases { get; set; }
}

public class DataBases
{
    public List<Global> Global { get; set; }
}

public class Global
{
    public DatabaseType DatabaseType { get; set; }

    public string DatabaseTypeName
    {
        get => DatabaseType.ToString();
        set => DatabaseType = (DatabaseType)Enum.Parse(typeof(DatabaseType), value);
    }
    
    
    public string ConnectionString { get; set; }
    public string ProviderName { get; set; }
    
    public string ContextName { get; set; }
}
