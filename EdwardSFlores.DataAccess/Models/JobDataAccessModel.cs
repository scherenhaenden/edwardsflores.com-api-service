namespace EdwardSFlores.DataAccess.Models;

public class JobDataAccessModel: BaseModelObject
{
    public Guid Guid { get; set; }
    public DateTime InsertedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsActive { get; set; } 
    public DateTime DateBegin   { get; set; }
    public DateTime DateEnd     { get; set; }
    public string   Company     { get; set; }
    public string   Position    { get; set; }
    public string   Description { get; set; }
    public string Location { get; set; }
    public List<TechnologyDataAccessModel> Technologies { get; set; }
}