using FluentMigrator;

namespace EdwardSFlores.DataAccess.Database.Migrations._122022;

[Migration(20221201000002)]
public class AddTechnologyV2Table : Migration
{
    public override void Up()
    {
        // only if table Technology exists
        if (Schema.Table("Technology").Exists())
        {
            /*Alter.Table("Technology")
                .AddColumn("JobStationGuid").AsGuid();*/
            //Schema.Table("Technology")..Column("JobStationGuid").

        }

    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}




[Migration(20221201000000)]
public class AddTechnologyTable: Migration
{
    
    public override void Up()
    {
        // Check if table exists
        if (!Schema.Table("Technology").Exists())
        {
            /*base properties
               public Guid Guid { get; set; }
    public DateTime InsertedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsActive { get; set; } = true;
             */
            
            /*Technology own properties
             [Required]
    public string Name { get; set; } = null!;
    
    public string? Description { get; set; }
    
    public string? Image { get; set; }
    
    public string? Url { get; set; }
    
    public int? ExperienceLevel { get; set; }
             */
            
            
            // Create table
            Create.Table("Technology")
                .WithColumn("Guid").AsGuid().PrimaryKey().PrimaryKey()
                .WithColumn("InsertedDate").AsDateTime().NotNullable()
                .WithColumn("UpdatedDate").AsDateTime().NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable()
                .WithColumn("Name").AsCustom("NVARCHAR(200)").Unique().NotNullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("Image").AsString().Nullable()
                .WithColumn("Url").AsString().Nullable()
                .WithColumn("ExperienceLevel").AsInt32().Nullable();
                
               // really great job thi time copilot! thanks!
               
        }
    }

    public override void Down()
    {
        
    }
}



[Migration(20221201000001)]
public class AddJobstationTable: Migration
{
    public override void Up()
    {
        // Check if table exists
        if (!Schema.Table("JobStation").Exists())
        {
            /*base properties
               public Guid Guid { get; set; }
    public DateTime InsertedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsActive { get; set; } = true;
             */
            
            /*JobStation own properties
    public DateTime DateBegin   { get; set; }
    public DateTime DateEnd     { get; set; }
    public string   Company     { get; set; }
    public string   Position    { get; set; }
    public string   Description { get; set; }
    public string Location { get; set; }
    public virtual ICollection<Technology> Technologies { get; set; }
             */
            
            
            // Create table
            Create.Table("JobStation")
                .WithColumn("Guid").AsGuid().PrimaryKey().PrimaryKey()
                .WithColumn("InsertedDate").AsDateTime().NotNullable()
                .WithColumn("UpdatedDate").AsDateTime().NotNullable()
                .WithColumn("IsActive").AsBoolean().NotNullable()
                .WithColumn("DateBegin").AsDateTime().NotNullable()
                .WithColumn("DateEnd").AsDateTime().NotNullable()
                .WithColumn("Company").AsCustom("NVARCHAR(200)").NotNullable()
                .WithColumn("Position").AsCustom("NVARCHAR(200)").NotNullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("Location").AsCustom("NVARCHAR(200)").NotNullable();





            // really great job thi time copilot! thanks!

            // really great job thi time copilot! thanks!

        }
    }

    public override void Down()
    {
        
    }
}
