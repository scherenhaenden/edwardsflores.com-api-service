using EdwardSFlores.BusinessLogic.Models;
using EdwardSFlores.BusinessLogic.Services.Administration.Roles;
using EdwardSFlores.DataAccess.Services.Private.AdministrationOfApplication;
using EdwardSFlores.Service.Services.Security.Jwt;
using Microsoft.AspNetCore.Mvc;

namespace EdwardSFlores.Service.Controllers.V1.PrivateApi;

[ApiController]
[Route("/v1/private-api/[controller]")]
public class PrivateCurriculumController : Controller
{
    private readonly IJobsStationsBusinessService _jobsStationsBusinessService;

    public PrivateCurriculumController(IJobsStationsBusinessService jobsStationsBusinessService)
    {
        _jobsStationsBusinessService = jobsStationsBusinessService;
    }
    // get jobs with pagination
    [AuthorizeViaJwtV1]
    [HttpGet]
    [Route("get-Job-station")]
    public IActionResult GetJobStation([FromQuery] int page, [FromQuery] int pageSize)
    {
        var result = _jobsStationsBusinessService.GetJobs(page, pageSize);
        return Ok(result);
    }


    //get-Job-station by guid
    [AuthorizeViaJwtV1]
    [HttpGet]
    [Route("get-Job-station-by-guid")]
    public IActionResult GetJobstation(Guid guid)
    {
        return Ok(_jobsStationsBusinessService.GetJobById(guid));
    }
    
    // add jobstation
    [AuthorizeViaJwtV1]
    [HttpPost]
    [Route("add-Job-station")]
    public IActionResult AddJobstation(JobStationAdministrationAddApiModel jobStation)
    {
        var jobStationBusinessModel = jobStation.MapObjToObj<JobStationBusinessModel>();
        return Ok(_jobsStationsBusinessService.AddJob(jobStationBusinessModel));
    }
    
    // update jobstation
    [AuthorizeViaJwtV1]
    [HttpPut]
    [Route("update-Job-station")]
    public IActionResult UpdateJobstation(JobStationAdministrationApiModel jobStation)
    {
        // map api model
        var jobStationBusinessModel = jobStation.MapObjToObj<JobStationBusinessModel>();
        return Ok(_jobsStationsBusinessService.UpdateJob(jobStationBusinessModel));
    }
    
    
    
    
    
    
    
}

public class JobStationAdministrationAddApiModel
{
    public DateTime DateBegin   { get; set; }
    public DateTime DateEnd     { get; set; }
    public string?   Company     { get; set; }
    public string?   Position    { get; set; }
    public string?   Description { get; set; }
    public string? Location { get; set; }
    public List<TechnologyApiModel>? Technologies { get; set; }
}

public class JobStationAdministrationApiModel: BaseApiModel
{
    public DateTime DateBegin   { get; set; }
    public DateTime DateEnd     { get; set; }
    public string?   Company     { get; set; }
    public string?   Position    { get; set; }
    public string?   Description { get; set; }
    public string? Location { get; set; }
    public List<TechnologyApiModel>? Technologies { get; set; }
}

public class TechnologyApiModel : BaseApiModel
{
    public string Name { get; set; } = null!;
    
    public string? Description { get; set; }
    
    public string? Image { get; set; }
    
    public string? Url { get; set; }
    
    public int? ExperienceLevel { get; set; }
}


public class BaseApiModel
{
    public Guid Guid { get; set; }
    public DateTime InsertedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsActive { get; set; } 
}