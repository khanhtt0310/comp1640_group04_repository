namespace Group04_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateStudentCourseTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.StudentCourse", new[] { "GradeGroupId" });
            AlterColumn("dbo.StudentCourse", "Mark", c => c.Single());
            AlterColumn("dbo.StudentCourse", "GradeGroupId", c => c.Int());
            CreateIndex("dbo.StudentCourse", "GradeGroupId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.StudentCourse", new[] { "GradeGroupId" });
            AlterColumn("dbo.StudentCourse", "GradeGroupId", c => c.Int(nullable: false));
            AlterColumn("dbo.StudentCourse", "Mark", c => c.Single(nullable: false));
            CreateIndex("dbo.StudentCourse", "GradeGroupId");
        }
    }
}
