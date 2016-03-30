namespace Group04_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeData : DbMigration
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
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Faculty",
                c => new
                    {
                        FacultyId = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(nullable: false, maxLength: 255),
                        Note = c.String(),
                        GeneralStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FacultyId)
                .ForeignKey("dbo.GeneralStatus", t => t.GeneralStatusId)
                .Index(t => t.GeneralStatusId);
            
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
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        StatusId = c.Int(nullable: false),
                        UserName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 150),
                        Password = c.String(maxLength: 100),
                        Faculty_FacultyId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.GeneralStatus", t => t.StatusId)
                .ForeignKey("dbo.Faculty", t => t.Faculty_FacultyId)
                .Index(t => t.StatusId)
                .Index(t => t.Faculty_FacultyId);
            
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
                "dbo.StudentCourse",
                c => new
                    {
                        StudentCourseId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Mark = c.Single(nullable: false),
                        Comment = c.String(),
                        GradeGroup = c.Int(),
                        GeneralStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentCourseId)
                .ForeignKey("dbo.Course", t => t.CourseId)
                .ForeignKey("dbo.GeneralStatus", t => t.GeneralStatusId)
                .ForeignKey("dbo.Student", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId)
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
            
            CreateTable(
                "dbo.UserCourse",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Course_CourseId })
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.Course_CourseId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Course_CourseId);
            
            CreateTable(
                "dbo.RoleUser",
                c => new
                    {
                        Role_RoleId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_RoleId, t.User_UserId })
                .ForeignKey("dbo.Role", t => t.Role_RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Role_RoleId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "StatusId", "dbo.GeneralStatus");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.StudentCourse", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentCourse", "GeneralStatusId", "dbo.GeneralStatus");
            DropForeignKey("dbo.StudentCourse", "CourseId", "dbo.Course");
            DropForeignKey("dbo.FacultyCourse", "GeneralStatusId", "dbo.GeneralStatus");
            DropForeignKey("dbo.FacultyCourse", "FacultyId", "dbo.Faculty");
            DropForeignKey("dbo.FacultyCourse", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Student", "GeneralStatusId", "dbo.GeneralStatus");
            DropForeignKey("dbo.User", "Faculty_FacultyId", "dbo.Faculty");
            DropForeignKey("dbo.User", "StatusId", "dbo.GeneralStatus");
            DropForeignKey("dbo.RoleUser", "User_UserId", "dbo.User");
            DropForeignKey("dbo.RoleUser", "Role_RoleId", "dbo.Role");
            DropForeignKey("dbo.Role", "StatusId", "dbo.GeneralStatus");
            DropForeignKey("dbo.UserCourse", "Course_CourseId", "dbo.Course");
            DropForeignKey("dbo.UserCourse", "User_UserId", "dbo.User");
            DropForeignKey("dbo.Faculty", "GeneralStatusId", "dbo.GeneralStatus");
            DropIndex("dbo.RoleUser", new[] { "User_UserId" });
            DropIndex("dbo.RoleUser", new[] { "Role_RoleId" });
            DropIndex("dbo.UserCourse", new[] { "Course_CourseId" });
            DropIndex("dbo.UserCourse", new[] { "User_UserId" });
            DropIndex("dbo.UserRole", new[] { "StatusId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.StudentCourse", new[] { "GeneralStatusId" });
            DropIndex("dbo.StudentCourse", new[] { "CourseId" });
            DropIndex("dbo.StudentCourse", new[] { "StudentId" });
            DropIndex("dbo.FacultyCourse", new[] { "GeneralStatusId" });
            DropIndex("dbo.FacultyCourse", new[] { "CourseId" });
            DropIndex("dbo.FacultyCourse", new[] { "FacultyId" });
            DropIndex("dbo.Student", new[] { "GeneralStatusId" });
            DropIndex("dbo.Role", new[] { "StatusId" });
            DropIndex("dbo.User", new[] { "Faculty_FacultyId" });
            DropIndex("dbo.User", new[] { "StatusId" });
            DropIndex("dbo.Faculty", new[] { "GeneralStatusId" });
            DropTable("dbo.RoleUser");
            DropTable("dbo.UserCourse");
            DropTable("dbo.UserRole");
            DropTable("dbo.StudentCourse");
            DropTable("dbo.FacultyCourse");
            DropTable("dbo.Student");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.GeneralStatus");
            DropTable("dbo.Faculty");
            DropTable("dbo.Course");
        }
    }
}
