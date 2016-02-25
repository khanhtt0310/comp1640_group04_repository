namespace Group04_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourse_CourseCode_Column : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseUser", "CourseId", "dbo.Course");
            DropPrimaryKey("dbo.Course");
            AddColumn("dbo.Course", "CourseCode", c => c.String(maxLength: 10));
            AlterColumn("dbo.Course", "CourseId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Course", "CourseId");
            AddForeignKey("dbo.CourseUser", "CourseId", "dbo.Course", "CourseId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseUser", "CourseId", "dbo.Course");
            DropPrimaryKey("dbo.Course");
            AlterColumn("dbo.Course", "CourseId", c => c.Int(nullable: false));
            DropColumn("dbo.Course", "CourseCode");
            AddPrimaryKey("dbo.Course", "CourseId");
            AddForeignKey("dbo.CourseUser", "CourseId", "dbo.Course", "CourseId", cascadeDelete: true);
        }
    }
}
