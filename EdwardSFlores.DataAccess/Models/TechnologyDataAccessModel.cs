namespace EdwardSFlores.DataAccess.Models;

public class TechnologyDataAccessModel : BaseModelObject
{
    public string Name { get; set; } = null!;
    
    public string? Description { get; set; }
    
    public string? Image { get; set; }
    
    public string? Url { get; set; }
    
    public int? ExperienceLevel { get; set; }
}