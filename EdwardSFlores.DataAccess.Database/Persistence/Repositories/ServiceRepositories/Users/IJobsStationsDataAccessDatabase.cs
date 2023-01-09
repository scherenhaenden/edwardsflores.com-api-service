using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Repositories;

namespace EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;

public interface IJobsStationsDataAccessDatabase : IRepository<JobStation>
{
    // get jobs by pagination
    public List<JobStation> GetJobs(int page, int pageSize);


    public JobStation? GetJobById(Guid guid);


    public JobStation UpdateJob(JobStation job);
    
    // add new job
    public JobStation AddJob(JobStation job);

}