using EdwardSFlores.BusinessLogic.Models;
using EdwardSFlores.DataAccess.Services.Public.Jobs;

namespace EdwardSFlores.BusinessLogic.Services.Administration.Roles;

public interface IJobsStationsBusinessService
{
    public List<JobStationBusinessModel> GetJobs(int page, int pageSize);


    public JobStationBusinessModel? GetJobById(Guid guid);


    public JobStationBusinessModel UpdateJob(JobStationBusinessModel job);
    
    // add new job
    public JobStationBusinessModel AddJob(JobStationBusinessModel job);
}