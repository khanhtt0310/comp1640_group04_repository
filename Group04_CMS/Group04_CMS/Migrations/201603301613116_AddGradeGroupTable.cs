namespace Group04_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGradeGroupTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GradeGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.StudentCourse", "GradeGroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.StudentCourse", "GradeGroupId");
            AddForeignKey("dbo.StudentCourse", "GradeGroupId", "dbo.GradeGroup", "Id");
            DropColumn("dbo.StudentCourse", "GradeGroup");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StudentCourse", "GradeGroup", c => c.Int());
            DropForeignKey("dbo.StudentCourse", "GradeGroupId", "dbo.GradeGroup");
            DropIndex("dbo.StudentCourse", new[] { "GradeGroupId" });
            DropColumn("dbo.StudentCourse", "GradeGroupId");
            DropTable("dbo.GradeGroup");
        }
    }
}
