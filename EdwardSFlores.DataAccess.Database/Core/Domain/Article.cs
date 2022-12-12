using EdwardSFlores.DataAccess.Database.Core.BaseDomain;

namespace EdwardSFlores.DataAccess.Database.Core.Domain;

public class Article: BaseEntity
{
    public Article ()
    {
        Author = new User();
    }
    
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime PublicationDate { get; set; }
    
    
    public virtual User Author { get; set; }
}