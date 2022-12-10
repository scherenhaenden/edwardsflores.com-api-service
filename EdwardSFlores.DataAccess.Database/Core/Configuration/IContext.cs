using EdwardSFlores.DataAccess.Database.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace EdwardSFlores.DataAccess.Database.Core.Configuration
{
    public interface IContext
    {
        // Add all the fields from the name space IdentityService.DataAccess.Database.Core.Domain
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    

    }
}