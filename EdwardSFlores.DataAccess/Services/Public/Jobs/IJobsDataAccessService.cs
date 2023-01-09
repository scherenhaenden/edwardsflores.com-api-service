using EdwardSFlores.DataAccess.Models;

namespace EdwardSFlores.DataAccess.Services.Public.Jobs;

public interface IJobsDataAccessService
{

    // get list with with pagination
    List<JobDataAccessModel> GetJobs(int page, int pageSize);
    
    // get job by guid
    JobDataAccessModel GetJobById(Guid guid);
    
    // update job
    JobDataAccessModel UpdateJob(JobDataAccessModel job);
}