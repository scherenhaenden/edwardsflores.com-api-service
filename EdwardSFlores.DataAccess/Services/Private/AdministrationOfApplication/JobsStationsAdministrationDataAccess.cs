using EdwardSFlores.DataAccess.Database.ContextManagement;
using EdwardSFlores.DataAccess.Database.Core.Domain;
using EdwardSFlores.DataAccess.Database.Persistence.Unities.ServiceUnities;
using EdwardSFlores.DataAccess.Models;

namespace EdwardSFlores.DataAccess.Services.Private.AdministrationOfApplication;

public class JobsStationsAdministrationDataAccess : IJobsStationsAdministrationDataAccess
{

    private readonly IPublicUserUnity _publicUserUnity;

    public JobsStationsAdministrationDataAccess(IDataContextManager dataContextManager)
    {
        _publicUserUnity = new PublicUserUnity(dataContextManager);
    }
    
    public List<JobDataAccessModel> GetJobs(int page, int pageSize)
    {
        
        var roles = _publicUserUnity.Jobs.GetJobs(page, pageSize);
        
        return roles.MapObjToObj<List<JobDataAccessModel>>();
    }

    public JobDataAccessModel? GetJobById(Guid guid)
    {
        var job = _publicUserUnity.Jobs.GetJobById(guid);
        return job.MapObjToObj<JobDataAccessModel>();
    }

    public JobDataAccessModel UpdateJob(JobDataAccessModel job)
    {
        var jobEntity = job.MapObjToObj<JobStation>();
        var updatedJob = _publicUserUnity.Jobs.UpdateJob(jobEntity);
        return updatedJob.MapObjToObj<JobDataAccessModel>();
    }

    public JobDataAccessModel AddJob(JobDataAccessModel job)
    {
        var jobAdded = _publicUserUnity.Jobs.AddJob(job.MapObjToObj<JobStation>());
        return jobAdded.MapObjToObj<JobDataAccessModel>();
    }
}