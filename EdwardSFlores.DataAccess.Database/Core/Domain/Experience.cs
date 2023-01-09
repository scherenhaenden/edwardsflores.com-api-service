using EdwardSFlores.DataAccess.Database.Core.BaseDomain;

namespace EdwardSFlores.DataAccess.Database.Core.Domain;

public class Experience : BaseEntity
{
    public Experience()
    {
        
    }
    
    public string Company { get; set; }
    
}