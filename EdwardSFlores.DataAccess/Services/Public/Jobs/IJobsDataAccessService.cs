using EdwardSFlores.DataAccess.Models;

namespace EdwardSFlores.DataAccess.Services.Public.Jobs;

public interface IJobsDataAccessService
{
    // get list with all jobs
    List<JobDataAccessModel> GetJobs();
    
    // get job by guid
    JobDataAccessModel GetJobById(Guid guid);
    
    // update job
    JobDataAccessModel UpdateJob(JobDataAccessModel job);
}