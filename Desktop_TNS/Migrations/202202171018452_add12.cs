namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Equipments", "work", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Equipments", "work");
        }
    }
}
