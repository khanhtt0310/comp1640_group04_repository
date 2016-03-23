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
                    })
                .PrimaryKey(t => t.CourseId);
            
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
            DropForeignKey("dbo.User", "StatusId", "dbo.GeneralStatus");
            DropForeignKey("dbo.RoleUser", "User_UserId", "dbo.User");
            DropForeignKey("dbo.RoleUser", "Role_RoleId", "dbo.Role");
            DropForeignKey("dbo.Role", "StatusId", "dbo.GeneralStatus");
            DropForeignKey("dbo.UserCourse", "Course_CourseId", "dbo.Course");
            DropForeignKey("dbo.UserCourse", "User_UserId", "dbo.User");
            DropIndex("dbo.RoleUser", new[] { "User_UserId" });
            DropIndex("dbo.RoleUser", new[] { "Role_RoleId" });
            DropIndex("dbo.UserCourse", new[] { "Course_CourseId" });
            DropIndex("dbo.UserCourse", new[] { "User_UserId" });
            DropIndex("dbo.UserRole", new[] { "StatusId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.Role", new[] { "StatusId" });
            DropIndex("dbo.User", new[] { "StatusId" });
            DropTable("dbo.RoleUser");
            DropTable("dbo.UserCourse");
            DropTable("dbo.UserRole");
            DropTable("dbo.GeneralStatus");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.Course");
        }
    }
}
