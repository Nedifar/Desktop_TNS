namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Raions", "area", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Raions", "area", c => c.Double(nullable: false));
        }
    }
}
