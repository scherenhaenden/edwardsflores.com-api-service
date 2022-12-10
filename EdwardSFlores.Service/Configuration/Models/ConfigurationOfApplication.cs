namespace EdwardSFlores.Service.Configuration.Models;

public class ConfigurationOfApplication
{
    public DataAccess DataAccess { get; set; }
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
