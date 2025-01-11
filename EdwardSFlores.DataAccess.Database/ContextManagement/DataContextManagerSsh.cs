using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Migrations;
using EdwardSFlores.DataAccess.Database.Persistence.Configuration;
using EdwardSFlores.DataAccess.Database.Persistence.Unities;
using Microsoft.EntityFrameworkCore;
using TunnelConnector.Credentials;
using TunnelConnector.LoadBalancer;
using TunnelConnector.Protocls;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Renci.SshNet;

namespace EdwardSFlores.DataAccess.Database.ContextManagement;

public class DataContextManagerSsh: IDataContextManager
{
    private readonly DbContextManagementModel _dbContextManagementModel;

    public DbContextEdward DbContextEdward { get; private set; }
    public IGenericUnitOfWork GenericUnityOfWork { get; private set; }
    
    private static ILoadBalancer _loadBalancer;
    
    public DataContextManagerSsh(DbContextManagementModel dbContextManagementModel)
    {
        _dbContextManagementModel = dbContextManagementModel;
        CreateContextWithSshTunneling(_dbContextManagementModel);
    }
    public DbContextManagementModel DbContextManagementModel { get; }

    private void CreateContextWithSshTunneling(DbContextManagementModel dbContextManagementModel)
    {
        var loadBalancerConfiguration = new LoadBalancerConfiguration()
        {
            Localhost = dbContextManagementModel.TunnelingModel.Localhost,
            LocalPorts = dbContextManagementModel.TunnelingModel.LocalPorts,
            //LocalPorts = new int []{ 5000, 5001, 5002},
            ForeignHost = dbContextManagementModel.TunnelingModel.ForeignHost,
            ForeignPort = dbContextManagementModel.TunnelingModel.ForeignPort,
            User = dbContextManagementModel.TunnelingModel.User,
            Password = dbContextManagementModel.TunnelingModel.Password,
            ProtocolPort = dbContextManagementModel.TunnelingModel.ProtocolPort,
            CurrentProtocol = AvailableProtocols.Ssh
        };
        
        //loadBalancerConfiguration = JsonConvert.DeserializeObject<LoadBalancerConfiguration>(@"{""Localhost"":""localhost"",""LocalPorts"":[33060,33061,33062,33063],""ForeignHost"":""81.169.225.146"",""ForeignPort"":3306,""User"":""rockadm"",""Password"":""W9e5br~0"",""ProtocolPort"":22,""CurrentProtocol"":0}");
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
        var connectionString = dbContextManagementModel.DbConnectionString.Replace("Port=3306", $"Port={portReplace}");
        
        //new RunMigrations(connectionString);
        
        // create DbContextOptions<DbContextEdward> options
        var options = new DbContextOptionsBuilder<DbContextEdward>();
        //options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        try
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
               
            // create db context
            DbContextEdward = new DbContextEdward(options.Options);
            GenericUnityOfWork = new GenericGenericUnitOfWork(DbContextEdward);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

            
    }
    
        public static (SshClient SshClient, uint Port) ConnectSsh(string sshHostName, string sshUserName, string sshPassword = null,
        string sshKeyFile = null, string sshPassPhrase = null, int sshPort = 22, string databaseServer = "localhost", int databasePort = 3306)
    {
        // check arguments
        if (string.IsNullOrEmpty(sshHostName))
            throw new ArgumentException($"{nameof(sshHostName)} must be specified.", nameof(sshHostName));
        if (string.IsNullOrEmpty(sshHostName))
            throw new ArgumentException($"{nameof(sshUserName)} must be specified.", nameof(sshUserName));
        if (string.IsNullOrEmpty(sshPassword) && string.IsNullOrEmpty(sshKeyFile))
            throw new ArgumentException($"One of {nameof(sshPassword)} and {nameof(sshKeyFile)} must be specified.");
        if (string.IsNullOrEmpty(databaseServer))
            throw new ArgumentException($"{nameof(databaseServer)} must be specified.", nameof(databaseServer));

        // define the authentication methods to use (in order)
        var authenticationMethods = new List<AuthenticationMethod>();
        if (!string.IsNullOrEmpty(sshKeyFile))
        {
            authenticationMethods.Add(new PrivateKeyAuthenticationMethod(sshUserName,
                new PrivateKeyFile(sshKeyFile, string.IsNullOrEmpty(sshPassPhrase) ? null : sshPassPhrase)));
        }
        if (!string.IsNullOrEmpty(sshPassword))
        {
            authenticationMethods.Add(new PasswordAuthenticationMethod(sshUserName, sshPassword));
        }

        // connect to the SSH server
        var sshClient = new SshClient(new ConnectionInfo(sshHostName, sshPort, sshUserName, authenticationMethods.ToArray()));
        sshClient.Connect();

        // forward a local port to the database server and port, using the SSH server
        var forwardedPort = new ForwardedPortLocal("127.0.0.1", databaseServer, (uint) databasePort);
        sshClient.AddForwardedPort(forwardedPort);
        forwardedPort.Start();

        return (sshClient, forwardedPort.BoundPort);
    }
}


public class DataContextManagerLocal: IDataContextManager
{
    private readonly DbContextManagementModel _dbContextManagementModel;

    public DbContextEdward DbContextEdward { get; private set; }
    public IGenericUnitOfWork GenericUnityOfWork { get; private set; }
    private static ILoadBalancer _loadBalancer;
    
    public DataContextManagerLocal(DbContextManagementModel dbContextManagementModel)
    {
        _dbContextManagementModel = dbContextManagementModel;
        CreateContextWithSshTunneling(_dbContextManagementModel);
    }
    public DbContextManagementModel DbContextManagementModel { get; }

    private void CreateContextWithSshTunneling(DbContextManagementModel dbContextManagementModel)
    {
        //new RunMigrations(dbContextManagementModel.DbConnectionString);
        // create DbContextOptions<DbContextEdward> options
        var options = new DbContextOptionsBuilder<DbContextEdward>();
        //options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        try
        {
            options.UseMySql(dbContextManagementModel.DbConnectionString, ServerVersion.AutoDetect(dbContextManagementModel.DbConnectionString));
               
            // create db context
            DbContextEdward = new DbContextEdward(options.Options);
            GenericUnityOfWork = new GenericGenericUnitOfWork(DbContextEdward);
        }
        catch (Exception e)
        {
            try
            {
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
           
        }

            
    }
}