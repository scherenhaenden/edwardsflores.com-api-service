using EdwardSFlores.DataAccess.Database.Core.BaseDomain;

namespace EdwardSFlores.DataAccess.Database.Core.Domain;

public class JobStation: BaseEntity
{
    public DateTime DateBegin   { get; set; }
    public DateTime DateEnd     { get; set; }
    public string   Company     { get; set; }
    public string   Position    { get; set; }
    public string   Description { get; set; }
    public string Location { get; set; }
    public string Technologies { get; set; }
}


