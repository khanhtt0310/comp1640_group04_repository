namespace Group04_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RoleUser", name: "Role_RoleId", newName: "RoleId");
            RenameColumn(table: "dbo.RoleUser", name: "User_UserId", newName: "UserId");
            RenameIndex(table: "dbo.RoleUser", name: "IX_Role_RoleId", newName: "IX_RoleId");
            RenameIndex(table: "dbo.RoleUser", name: "IX_User_UserId", newName: "IX_UserId");
            AddColumn("dbo.Course", "CourseCode", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course", "CourseCode");
            RenameIndex(table: "dbo.RoleUser", name: "IX_UserId", newName: "IX_User_UserId");
            RenameIndex(table: "dbo.RoleUser", name: "IX_RoleId", newName: "IX_Role_RoleId");
            RenameColumn(table: "dbo.RoleUser", name: "UserId", newName: "User_UserId");
            RenameColumn(table: "dbo.RoleUser", name: "RoleId", newName: "Role_RoleId");
        }
    }
}
