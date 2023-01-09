using EdwardSFlores.DataAccess.Database.Core.BaseDomain;
using Microsoft.EntityFrameworkCore;

namespace EdwardSFlores.DataAccess.Database.Core.Domain;

[Index(nameof(Name), IsUnique = true)]
public class Role: BaseEntity
{
    public Role ()
    {
        Users = new List<User>();
        Tokens = new List<Token>();
    }
    
    public string Name { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public virtual ICollection<User> Users { get; set; }
    
    public virtual ICollection<Token> Tokens { get; set; }
    
    
    
    
}