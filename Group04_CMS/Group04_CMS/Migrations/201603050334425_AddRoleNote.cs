namespace Group04_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoleNote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Email", c => c.String(maxLength: 150));
            AddColumn("dbo.Role", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Role", "Note");
            DropColumn("dbo.User", "Email");
        }
    }
}
