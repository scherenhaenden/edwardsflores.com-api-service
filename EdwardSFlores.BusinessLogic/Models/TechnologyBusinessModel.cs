using EdwardSFlores.BusinessLogic.Models.Base;

namespace EdwardSFlores.BusinessLogic.Models;

public class TechnologyBusinessModel : BaseModelBusinessObject
{
    public string Name { get; set; } = null!;
    
    public string? Description { get; set; }
    
    public string? Image { get; set; }
    
    public string? Url { get; set; }
    
    public int? ExperienceLevel { get; set; }
}