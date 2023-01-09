using EdwardSFlores.DataAccess.Database.Core.BaseDomain;
using Microsoft.EntityFrameworkCore;

namespace EdwardSFlores.DataAccess.Database.Core.Domain;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Username), IsUnique = true)]
public class User : BaseEntity
{
    public User()
    {
        UserRoles = new HashSet<Role>();
        DirectTokens = new HashSet<Token>();
        JobStations = new HashSet<JobStation>();
    }
    
    
    // Add fields for user simple for first draft
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;
    
    public virtual ICollection<Role> UserRoles { get; set; }
    
    public virtual ICollection<Token> DirectTokens { get; set; }
    
    public virtual ICollection<JobStation> JobStations { get; set; }
    
}