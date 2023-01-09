using EdwardSFlores.BusinessLogic.Models;
using EdwardSFlores.DataAccess.Models;
using EdwardSFlores.DataAccess.Services.Private.AdministrationOfApplication;

namespace EdwardSFlores.BusinessLogic.Services.Administration.Roles;

public class JobsStationsBusinessService: IJobsStationsBusinessService
{
    private readonly IJobsStationsAdministrationDataAccess _jobsStationsAdministrationDataAccess;


    public JobsStationsBusinessService(IJobsStationsAdministrationDataAccess jobsStationsAdministrationDataAccess)
    {
        _jobsStationsAdministrationDataAccess = jobsStationsAdministrationDataAccess;
    }

    public List<JobStationBusinessModel> GetJobs(int page, int pageSize)
    {
        //var roleServiceModel = role.MapObjToObj<RoleDataAccessModel>();
        //roleServiceModel = _rolesDataAccessService.AddRole(roleServiceModel);
        //return roleServiceModel.MapObjToObj<RoleBusinessModel>();
        return _jobsStationsAdministrationDataAccess.GetJobs(page, pageSize).Select(x => x.MapObjToObj<JobStationBusinessModel>()).ToList();
    }

    public JobStationBusinessModel? GetJobById(Guid guid)
    {
        var job = _jobsStationsAdministrationDataAccess.GetJobById(guid);
        return job.MapObjToObj<JobStationBusinessModel>();
    }

    public JobStationBusinessModel UpdateJob(JobStationBusinessModel job)
    {
        var jobServiceModel = job.MapObjToObj<JobDataAccessModel>();
        jobServiceModel = _jobsStationsAdministrationDataAccess.UpdateJob(jobServiceModel);
        return jobServiceModel.MapObjToObj<JobStationBusinessModel>();
    }

    public JobStationBusinessModel AddJob(JobStationBusinessModel job)
    {
        var jobServiceModel = job.MapObjToObj<JobDataAccessModel>();
        jobServiceModel = _jobsStationsAdministrationDataAccess.AddJob(jobServiceModel);
        return jobServiceModel.MapObjToObj<JobStationBusinessModel>();
    }
}