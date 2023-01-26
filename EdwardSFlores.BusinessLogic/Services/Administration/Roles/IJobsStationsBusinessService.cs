using EdwardSFlores.BusinessLogic.Models;

namespace EdwardSFlores.BusinessLogic.Services.Administration.Roles;

public interface IJobsStationsBusinessService
{
    public List<JobStationBusinessModel> GetJobs(int page, int pageSize);


    public JobStationBusinessModel? GetJobById(Guid guid);


    public JobStationBusinessModel UpdateJob(JobStationBusinessModel job);
    
    // add new job
    public JobStationBusinessModel AddJob(JobStationBusinessModel job);
}