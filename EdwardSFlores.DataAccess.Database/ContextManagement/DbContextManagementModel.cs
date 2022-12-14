using System.IO.Pipes;

namespace EdwardSFlores.DataAccess.Database.ContextManagement;

public class TunnelingModel
{
    public string Localhost { get; set; }
    public int[] LocalPorts { get; set; }
    public string ForeignHost { get; set; }
    public int ForeignPort { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
    public int ProtocolPort { get; set; }
}

public class DbContextManagementModel
{
    private TunnelingModel _tunnelingModel = new TunnelingModel();


    public string DbConnectionString { get; set; }

    public TunnelingModel TunnelingModel { get { return _tunnelingModel; } set { _tunnelingModel = value; } } 
    
}