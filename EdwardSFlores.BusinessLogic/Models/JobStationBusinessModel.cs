using EdwardSFlores.BusinessLogic.Services.Administration.Roles;

namespace EdwardSFlores.BusinessLogic.Models;

public class JobStationBusinessModel: BaseBusinessModel
{
    public DateTime DateBegin   { get; set; }
    public DateTime DateEnd     { get; set; }
    public string   Name     { get; set; }
    public string   Company     { get; set; }
    public string   Position    { get; set; }
    public string   Description { get; set; }
    public string Location { get; set; }
    public List<TechnologyBusinessModel> Technologies { get; set; }
}