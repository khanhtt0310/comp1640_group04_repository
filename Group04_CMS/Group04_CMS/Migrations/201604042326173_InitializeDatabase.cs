namespace Group04_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(nullable: false, maxLength: 10),
                        CourseName = c.String(nullable: false, maxLength: 255),
                        CourseStatus = c.String(nullable: false, maxLength: 1),
                        CourseLeaderId = c.Int(nullable: false),
                        CourseModeratorId = c.Int(nullable: false),
                        ReportGroup = c.Int(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.User", t => t.CourseLeaderId)
                .ForeignKey("dbo.User", t => t.CourseModeratorId)
                .Index(t => t.CourseLeaderId)
                .Index(t => t.CourseModeratorId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        StatusId = c.Int(nullable: false),
                        UserName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 150),
                        Password = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.GeneralStatus", t => t.StatusId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 255),
                        Note = c.String(),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.GeneralStatus", t => t.StatusId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.GeneralStatus",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                        Note = c.String(),
                        CreateTime = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateTime = c.DateTimeOffset(nullable: false, precision: 7),
                        CreateUserId = c.Int(),
                        UpdateUserId = c.Int(),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.Faculty",
                c => new
                    {
                        FacultyId = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(nullable: false, maxLength: 255),
                        Note = c.String(),
                        DirectorId = c.Int(nullable: false),
                        ProViceId = c.Int(nullable: false),
                        GeneralStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FacultyId)
                .ForeignKey("dbo.User", t => t.DirectorId)
                .ForeignKey("dbo.GeneralStatus", t => t.GeneralStatusId)
                .ForeignKey("dbo.User", t => t.ProViceId)
                .Index(t => t.DirectorId)
                .Index(t => t.ProViceId)
                .Index(t => t.GeneralStatusId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentCode = c.String(),
                        Email = c.String(),
                        FullName = c.String(),
                        DateOfBirth = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        GeneralStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.GeneralStatus", t => t.GeneralStatusId)
                .Index(t => t.GeneralStatusId);
            
            CreateTable(
                "dbo.FacultyCourse",
                c => new
                    {
                        FacultyCourseId = c.Int(nullable: false, identity: true),
                        FacultyId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Note = c.String(),
                        GeneralStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FacultyCourseId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.Faculty", t => t.FacultyId)
                .ForeignKey("dbo.GeneralStatus", t => t.GeneralStatusId)
                .Index(t => t.FacultyId)
                .Index(t => t.CourseId)
                .Index(t => t.GeneralStatusId);
            
            CreateTable(
                "dbo.GradeGroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentCourse",
                c => new
                    {
                        StudentCourseId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Mark = c.Single(),
                        Comment = c.String(),
                        ReportState = c.Int(),
                        GradeGroupId = c.Int(),
                        GeneralStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentCourseId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.GeneralStatus", t => t.GeneralStatusId)
                .ForeignKey("dbo.GradeGroup", t => t.GradeGroupId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId)
                .Index(t => t.GradeGroupId)
                .Index(t => t.GeneralStatusId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Note = c.String(),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserRoleId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .ForeignKey("dbo.GeneralStatus", t => t.StatusId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "StatusId", "dbo.GeneralStatus");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.StudentCourse", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentCourse", "GradeGroupId", "dbo.GradeGroup");
            DropForeignKey("dbo.StudentCourse", "GeneralStatusId", "dbo.GeneralStatus");
            DropForeignKey("dbo.StudentCourse", "CourseId", "dbo.Course");
            DropForeignKey("dbo.FacultyCourse", "GeneralStatusId", "dbo.GeneralStatus");
            DropForeignKey("dbo.FacultyCourse", "FacultyId", "dbo.Faculty");
            DropForeignKey("dbo.FacultyCourse", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Student", "GeneralStatusId", "dbo.GeneralStatus");
            DropForeignKey("dbo.StudentCourse1", "Course_CourseId", "dbo.Course");
            DropForeignKey("dbo.StudentCourse1", "Student_StudentId", "dbo.Student");
            DropForeignKey("dbo.Faculty", "ProViceId", "dbo.User");
            DropForeignKey("dbo.Faculty", "GeneralStatusId", "dbo.GeneralStatus");
            DropForeignKey("dbo.Faculty", "DirectorId", "dbo.User");
            DropForeignKey("dbo.Course", "CourseModeratorId", "dbo.User");
            DropForeignKey("dbo.Course", "CourseLeaderId", "dbo.User");
            DropForeignKey("dbo.User", "StatusId", "dbo.GeneralStatus");
            DropForeignKey("dbo.Role", "StatusId", "dbo.GeneralStatus");
            DropIndex("dbo.UserRole", new[] { "StatusId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.StudentCourse", new[] { "GeneralStatusId" });
            DropIndex("dbo.StudentCourse", new[] { "GradeGroupId" });
            DropIndex("dbo.StudentCourse", new[] { "CourseId" });
            DropIndex("dbo.StudentCourse", new[] { "StudentId" });
            DropIndex("dbo.FacultyCourse", new[] { "GeneralStatusId" });
            DropIndex("dbo.FacultyCourse", new[] { "CourseId" });
            DropIndex("dbo.FacultyCourse", new[] { "FacultyId" });
            DropIndex("dbo.Student", new[] { "GeneralStatusId" });
            DropIndex("dbo.Faculty", new[] { "GeneralStatusId" });
            DropIndex("dbo.Faculty", new[] { "ProViceId" });
            DropIndex("dbo.Faculty", new[] { "DirectorId" });
            DropIndex("dbo.Role", new[] { "StatusId" });
            DropIndex("dbo.User", new[] { "StatusId" });
            DropIndex("dbo.Course", new[] { "CourseModeratorId" });
            DropIndex("dbo.Course", new[] { "CourseLeaderId" });
            DropTable("dbo.UserRole");
            DropTable("dbo.StudentCourse");
            DropTable("dbo.GradeGroup");
            DropTable("dbo.FacultyCourse");
            DropTable("dbo.Student");
            DropTable("dbo.Faculty");
            DropTable("dbo.GeneralStatus");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Course");
        }
    }
}
