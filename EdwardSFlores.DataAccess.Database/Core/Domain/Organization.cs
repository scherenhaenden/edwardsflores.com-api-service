using EdwardSFlores.DataAccess.Database.Core.BaseDomain;
using Microsoft.EntityFrameworkCore;

namespace EdwardSFlores.DataAccess.Database.Core.Domain;

[Index(nameof(Name), IsUnique = true)]
[Index(nameof(Name), nameof(Website),  IsUnique = true)]

public class Organization: BaseEntity
{
    public Organization()
    {
        Technologies = new HashSet<Technology>();
        JobStations = new HashSet<JobStation>();
        
    }
    
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? ZipCode { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Website { get; set; }
    
    public virtual ICollection<Technology>? Technologies { get; set; }
    public virtual ICollection<JobStation> JobStations { get; set; }

}

