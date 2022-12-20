namespace EdwardSFlores.DataAccess.Services.Public.Jobs;

public class BaseModelObject
{
    public Guid Guid { get; set; }
    public DateTime InsertedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsActive { get; set; } 
}