namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Raions", "name", c => c.String());
            AlterColumn("dbo.Raions", "countMentro", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Raions", "countMentro", c => c.Int(nullable: false));
            DropColumn("dbo.Raions", "name");
        }
    }
}
