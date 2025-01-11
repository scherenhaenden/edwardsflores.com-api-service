using EdwardSFlores.DataAccess.Models;

namespace EdwardSFlores.DataAccess.Services.Public.Jobs;

public class JobsDataAccessService: IJobsDataAccessService
{
  
    
    public List<JobDataAccessModel> GetJobs(int page, int pageSize)
    {
        throw new NotImplementedException();
    }

    public JobDataAccessModel GetJobById(Guid guid)
    {
        throw new NotImplementedException();
    }

    public JobDataAccessModel UpdateJob(JobDataAccessModel job)
    {
        throw new NotImplementedException();
    }
}