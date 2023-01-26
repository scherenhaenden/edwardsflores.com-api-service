using EdwardSFlores.DataAccess.Models;

namespace EdwardSFlores.DataAccess.Services.Private.AdministrationOfApplication;

public interface IJobsStationsAdministrationDataAccess
{
    // get jobs by pagination
    public List<JobDataAccessModel> GetJobs(int page, int pageSize);


    public JobDataAccessModel? GetJobById(Guid guid);


    public JobDataAccessModel UpdateJob(JobDataAccessModel job);
    
    // add new job
    public JobDataAccessModel AddJob(JobDataAccessModel job);
}