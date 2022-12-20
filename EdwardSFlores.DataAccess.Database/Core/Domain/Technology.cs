using System.ComponentModel.DataAnnotations;
using EdwardSFlores.DataAccess.Database.Core.BaseDomain;
using Microsoft.EntityFrameworkCore;

namespace EdwardSFlores.DataAccess.Database.Core.Domain;

[Index(nameof(Name), IsUnique = true)]
public class Technology : BaseEntity
{
    [Required]
    public string Name { get; set; } = null!;
    
    public string? Description { get; set; }
    
    public string? Image { get; set; }
    
    public string? Url { get; set; }
    
    public int? ExperienceLevel { get; set; }
}