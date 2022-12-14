using System.Diagnostics.CodeAnalysis;
using EdwardSFlores.DataAccess.Database.Core.Configuration;
using EdwardSFlores.DataAccess.Database.Core.Domain;
using Microsoft.EntityFrameworkCore;


namespace EdwardSFlores.DataAccess.Database.Persistence.Configuration
{
    [ExcludeFromCodeCoverage]
    public class DbContextEdward : DbContext, IContext
    {
        public DbContextEdward(DbContextOptions<DbContextEdward> options) : base(options)
        {
            try
            {
                base.Database.EnsureCreated();   
            }catch(Exception ex)
            {
            
            }

        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
   
    }
}