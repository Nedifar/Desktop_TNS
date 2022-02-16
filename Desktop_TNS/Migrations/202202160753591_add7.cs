namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Raions", "population", c => c.String());
            AlterColumn("dbo.Raions", "countMentro", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Raions", "countMentro", c => c.Double(nullable: false));
            AlterColumn("dbo.Raions", "population", c => c.Double(nullable: false));
        }
    }
}
