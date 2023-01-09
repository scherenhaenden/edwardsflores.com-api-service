using EdwardSFlores.DataAccess.Database.Core.Domain;

namespace EdwardSFlores.DataAccess.Services.Public.Curriculum;

public interface ICurriculumDataAccessService
{
    JobStation GetJobStationByGuid(Guid jobStationId);
    JobStation GetByCompanyName(string companyName);
}