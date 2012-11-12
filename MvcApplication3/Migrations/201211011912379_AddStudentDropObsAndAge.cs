namespace MvcApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentDropObsAndAge : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Student", "Age");
            DropColumn("dbo.Student", "Obs");
            DropColumn("dbo.Student", "Obs2");
            DropColumn("dbo.Student", "Obs3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "Obs3", c => c.String(maxLength: 200));
            AddColumn("dbo.Student", "Obs2", c => c.String(maxLength: 200));
            AddColumn("dbo.Student", "Obs", c => c.String(maxLength: 200));
            AddColumn("dbo.Student", "Age", c => c.Int(nullable: false));
        }
    }
}
