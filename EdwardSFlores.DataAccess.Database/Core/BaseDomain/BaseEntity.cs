using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EdwardSFlores.DataAccess.Database.Core.BaseDomain;

namespace EdwardSFlores.DataAccess.Database.Persistence.BaseDomain;

public class BaseEntity : IBaseEntity
{
    [Key]
    [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
    public Guid Guid { get; set; }
    public DateTime InsertedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsActive { get; set; } = true;
    
    
    public void OnNew()
    {
        Guid = Guid.NewGuid();
        InsertedDate = DateTime.Now;
        UpdatedDate = DateTime.Now;
    }

    public void OnUpdate()
    {
        UpdatedDate = DateTime.Now;
    }

}