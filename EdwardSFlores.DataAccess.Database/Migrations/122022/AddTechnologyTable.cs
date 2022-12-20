using FluentMigrator;

namespace EdwardSFlores.DataAccess.Database.Migrations._122022;

[Migration(20221201000000)]
public class AddTechTable: Migration
{
    public override void Up()
    {
        // Check if table exists
        if (!Schema.Table("Log").Exists())
        {
            // Create table
            Create.Table("Log")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("Thread").AsString(255).NotNullable()
                .WithColumn("Level").AsString(50).NotNullable()
                .WithColumn("Logger").AsString(255).NotNullable()
                .WithColumn("Message").AsString(int.MaxValue).NotNullable()
                .WithColumn("Exception").AsString(int.MaxValue).Nullable();
        }
        
        
        Create.Table("Log")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("Text").AsString();
    }

    public override void Down()
    {
        throw new NotImplementedException();
    }
}

[Migration(2022)]
public class AddLogTable : Migration
{
    public override void Up()
    {
        
        
        // Check if table exists
        if (!Schema.Table("Log").Exists())
        {
            // Create table
            Create.Table("Log")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Date").AsDateTime().NotNullable()
                .WithColumn("Thread").AsString(255).NotNullable()
                .WithColumn("Level").AsString(50).NotNullable()
                .WithColumn("Logger").AsString(255).NotNullable()
                .WithColumn("Message").AsString(int.MaxValue).NotNullable()
                .WithColumn("Exception").AsString(int.MaxValue).Nullable();
        }
        
        
        Create.Table("Log")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("Text").AsString();
    }

    public override void Down()
    {
        Delete.Table("Log");
    }
}