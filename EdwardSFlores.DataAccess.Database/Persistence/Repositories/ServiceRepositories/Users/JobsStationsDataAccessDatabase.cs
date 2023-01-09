using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Unities;
using EdwardSFlores.DataAccess.Database.Persistence.Configuration;

namespace EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;

public class JobsStationsDataAccessDatabase: GenericRepository<JobStation>, IJobsStationsDataAccessDatabase
{
    
    private readonly DbContextEdward _dbContextEdward;
    private readonly IGenericUnitOfWork _genericUnitOfWork;
    
    public JobsStationsDataAccessDatabase(IDataContextManager dataContextManager): base(dataContextManager.DbContextEdward)
    {
        
        _dbContextEdward = dataContextManager.DbContextEdward;
        _genericUnitOfWork = dataContextManager.GenericUnityOfWork;
    }

    

    public List<JobStation> GetJobs(int page, int pageSize)
    {
        return _genericUnitOfWork.JobStations.GetAll(page, pageSize).ToList();
    }

    public JobStation? GetJobById(Guid guid)
    {
        return _genericUnitOfWork.JobStations.FirstOrDefault(x => x.Guid == guid);
    }

    public JobStation UpdateJob(JobStation job)
    {
        _genericUnitOfWork.JobStations.Update(job);
        _genericUnitOfWork.Save();
        return job;
    }

    public JobStation AddJob(JobStation job)
    {
        _genericUnitOfWork.JobStations.Add(job);
        _genericUnitOfWork.Save();
        return job;
    }
}