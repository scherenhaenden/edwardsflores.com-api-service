using EdwardSFlores.DataAccess.Database.Core.BaseDomain;
using Microsoft.EntityFrameworkCore;

namespace EdwardSFlores.DataAccess.Database.Core.Domain;

[Index(nameof(Code), IsUnique = true)]
public class Token: BaseEntity
{
    public Token()
    {
        Users = new HashSet<User>();
        Roles = new HashSet<Role>();
    }
    public string Code { get; set; }
    public string Description { get; set; }
    
    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<Role> Roles { get; set; }
}