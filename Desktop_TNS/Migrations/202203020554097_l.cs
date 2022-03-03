namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class l : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BaseStations", "radius", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BaseStations", "radius");
        }
    }
}
