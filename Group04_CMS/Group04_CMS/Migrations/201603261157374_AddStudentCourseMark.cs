namespace Group04_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudentCourseMark : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculty",
                c => new
                    {
                        FacultyId = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(nullable: false, maxLength: 255),
                        FacultyStatus = c.String(nullable: false, maxLength: 1),
                        GeneralStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FacultyId)
                .ForeignKey("dbo.GeneralStatus", t => t.GeneralStatusId)
                .Index(t => t.GeneralStatusId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentCode = c.String(),
                        Email = c.String(),
                        FullName = c.String(),
                        DateOfBirth = c.DateTimeOffset(nullable: false, precision: 7),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        StudentStatus = c.Int(nullable: false),
                        GeneralStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.GeneralStatus", t => t.GeneralStatusId)
                .Index(t => t.GeneralStatusId);
            
            CreateTable(
                "dbo.FacultyCourse",
                c => new
                    {
                        Faculty_FacultyId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Faculty_FacultyId, t.Course_CourseId })
                .ForeignKey("dbo.Faculty", t => t.Faculty_FacultyId, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.Course_CourseId, cascadeDelete: true)
                .Index(t => t.Faculty_FacultyId)
                .Index(t => t.Course_CourseId);
            
            CreateTable(
                "dbo.StudentCourse",
                c => new
                    {
                        Student_StudentId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Course_CourseId })
                .ForeignKey("dbo.Student", t => t.Student_StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.Course_CourseId, cascadeDelete: true)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Course_CourseId);
            
            AddColumn("dbo.User", "Faculty_FacultyId", c => c.Int());
            CreateIndex("dbo.User", "Faculty_FacultyId");
            AddForeignKey("dbo.User", "Faculty_FacultyId", "dbo.Faculty", "FacultyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "GeneralStatusId", "dbo.GeneralStatus");
            DropForeignKey("dbo.StudentCourse", "Course_CourseId", "dbo.Course");
            DropForeignKey("dbo.StudentCourse", "Student_StudentId", "dbo.Student");
            DropForeignKey("dbo.User", "Faculty_FacultyId", "dbo.Faculty");
            DropForeignKey("dbo.Faculty", "GeneralStatusId", "dbo.GeneralStatus");
            DropForeignKey("dbo.FacultyCourse", "Course_CourseId", "dbo.Course");
            DropForeignKey("dbo.FacultyCourse", "Faculty_FacultyId", "dbo.Faculty");
            DropIndex("dbo.StudentCourse", new[] { "Course_CourseId" });
            DropIndex("dbo.StudentCourse", new[] { "Student_StudentId" });
            DropIndex("dbo.FacultyCourse", new[] { "Course_CourseId" });
            DropIndex("dbo.FacultyCourse", new[] { "Faculty_FacultyId" });
            DropIndex("dbo.Student", new[] { "GeneralStatusId" });
            DropIndex("dbo.User", new[] { "Faculty_FacultyId" });
            DropIndex("dbo.Faculty", new[] { "GeneralStatusId" });
            DropColumn("dbo.User", "Faculty_FacultyId");
            DropTable("dbo.StudentCourse");
            DropTable("dbo.FacultyCourse");
            DropTable("dbo.Student");
            DropTable("dbo.Faculty");
        }
    }
}
