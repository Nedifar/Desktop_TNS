namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbonentEquipments", "standart", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbonentEquipments", "standart");
        }
    }
}
