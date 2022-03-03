namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseStations",
                c => new
                    {
                        idBaseStation = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        area = c.Double(nullable: false),
                        frequince = c.Double(nullable: false),
                        type = c.String(),
                        begin = c.Int(nullable: false),
                        end = c.Int(nullable: false),
                        standart = c.String(),
                        installCoordinate = c.String(),
                    })
                .PrimaryKey(t => t.idBaseStation);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BaseStations");
        }
    }
}
