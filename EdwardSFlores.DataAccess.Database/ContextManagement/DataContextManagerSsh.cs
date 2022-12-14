using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Persistence.Configuration;
using EdwardSFlores.DataAccess.Database.Persistence.Unities;
using Microsoft.EntityFrameworkCore;
using TunnelConnector.Credentials;
using TunnelConnector.LoadBalancer;
using TunnelConnector.Protocls;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

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
            Console.WriteLine(e);
            throw;
        }

            
    }
}