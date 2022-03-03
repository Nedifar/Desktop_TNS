namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CRMs", "imagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CRMs", "imagePath");
        }
    }
}
