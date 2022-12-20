namespace EdwardSFlores.BusinessLogic.Services.Administration.Roles;

public class BaseBusinessModelObject
{
    public Guid Guid { get; set; }
    public DateTime InsertedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsActive { get; set; } 
}