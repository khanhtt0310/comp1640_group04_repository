namespace Group04_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataInitialization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(maxLength: 10),
                        CourseName = c.String(),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
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
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        StatusId = c.Int(nullable: false),
                        UserName = c.String(maxLength: 100),
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
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.GeneralStatus", t => t.StatusId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.RoleUser",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CourseUser",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseId, t.UserId })
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseUser", "UserId", "dbo.User");
            DropForeignKey("dbo.CourseUser", "CourseId", "dbo.Course");
            DropForeignKey("dbo.User", "StatusId", "dbo.GeneralStatus");
            DropForeignKey("dbo.RoleUser", "UserId", "dbo.User");
            DropForeignKey("dbo.RoleUser", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Role", "StatusId", "dbo.GeneralStatus");
            DropForeignKey("dbo.Course", "StatusId", "dbo.GeneralStatus");
            DropIndex("dbo.CourseUser", new[] { "UserId" });
            DropIndex("dbo.CourseUser", new[] { "CourseId" });
            DropIndex("dbo.RoleUser", new[] { "UserId" });
            DropIndex("dbo.RoleUser", new[] { "RoleId" });
            DropIndex("dbo.Role", new[] { "StatusId" });
            DropIndex("dbo.User", new[] { "StatusId" });
            DropIndex("dbo.Course", new[] { "StatusId" });
            DropTable("dbo.CourseUser");
            DropTable("dbo.RoleUser");
            DropTable("dbo.Role");
            DropTable("dbo.User");
            DropTable("dbo.GeneralStatus");
            DropTable("dbo.Course");
        }
    }
}
