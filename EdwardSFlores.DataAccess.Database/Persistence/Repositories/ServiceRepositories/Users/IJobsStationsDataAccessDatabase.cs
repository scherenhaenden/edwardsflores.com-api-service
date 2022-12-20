using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Core.Repositories;

namespace EdwardSFlores.DataAccess.Database.Persistence.Repositories.ServiceRepositories.Users;

public interface IJobsStationsDataAccessDatabase : IRepository<JobStation>
{
    public List<JobStation> GetJobs();


    public JobStation? GetJobById(Guid guid);


    public JobStation UpdateJob(JobStation job);
    
    // add new job
    public JobStation AddJob(JobStation job);

}