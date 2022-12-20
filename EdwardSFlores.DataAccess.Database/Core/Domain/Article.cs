using System.ComponentModel.DataAnnotations;
using EdwardSFlores.DataAccess.Database.Core.BaseDomain;

namespace EdwardSFlores.DataAccess.Database.Core.Domain;

public class Article: BaseEntity
{
    public Article ()
    {
        Author = new User();
    }
    [MaxLength(50)]
    public string Title { get; set; } = null!;
    [StringLength(15000)]
    public string Content { get; set; } = null!;
    public DateTime PublicationDate { get; set; }
    
    
    public virtual User Author { get; set; }
}