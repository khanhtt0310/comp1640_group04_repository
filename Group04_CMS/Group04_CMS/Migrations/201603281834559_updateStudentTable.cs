namespace Group04_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateStudentTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Student", "DateOfBirth", c => c.String());
            DropColumn("dbo.Student", "StudentStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "StudentStatus", c => c.Int(nullable: false));
            AlterColumn("dbo.Student", "DateOfBirth", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
    }
}
