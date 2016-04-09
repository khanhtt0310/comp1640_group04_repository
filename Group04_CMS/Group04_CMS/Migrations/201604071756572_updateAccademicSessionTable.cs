namespace Group04_CMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAccademicSessionTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccademicSession", "AccSessName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccademicSession", "AccSessName");
        }
    }
}
