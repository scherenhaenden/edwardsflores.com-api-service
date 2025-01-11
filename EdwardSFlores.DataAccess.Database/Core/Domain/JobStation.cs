using EdwardSFlores.DataAccess.Database.Core.BaseDomain;

namespace EdwardSFlores.DataAccess.Database.Core.Domain;

public class JobStation: BaseEntity
{
    public JobStation()
    {
        Technologies = new HashSet<Technology>();
    }
    
    public DateTime DateBegin   { get; set; }
    public DateTime DateEnd     { get; set; }
    
    public string  Position    { get; set; }
    public string  Description { get; set; }
    public string Location { get; set; }
    public virtual Organization Organization { get; set; }
    
    public virtual ICollection<Technology> Technologies { get; set; }
    
    public virtual User User { get; set; }
}


