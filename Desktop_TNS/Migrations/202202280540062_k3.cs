namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TarifServices", newName: "ServiceTarifs");
            DropPrimaryKey("dbo.ServiceTarifs");
            CreateTable(
                "dbo.AbonentTarifs",
                c => new
                    {
                        idAbonentTarif = c.Int(nullable: false, identity: true),
                        AbonentNumber = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.idAbonentTarif)
                .ForeignKey("dbo.Abonents", t => t.AbonentNumber)
                .Index(t => t.AbonentNumber);
            
            CreateTable(
                "dbo.TarifAbonentTarifs",
                c => new
                    {
                        Tarif_idTarif = c.Int(nullable: false),
                        AbonentTarif_idAbonentTarif = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tarif_idTarif, t.AbonentTarif_idAbonentTarif })
                .ForeignKey("dbo.Tarifs", t => t.Tarif_idTarif, cascadeDelete: true)
                .ForeignKey("dbo.AbonentTarifs", t => t.AbonentTarif_idAbonentTarif, cascadeDelete: true)
                .Index(t => t.Tarif_idTarif)
                .Index(t => t.AbonentTarif_idAbonentTarif);
            
            AddPrimaryKey("dbo.ServiceTarifs", new[] { "Service_idService", "Tarif_idTarif" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TarifAbonentTarifs", "AbonentTarif_idAbonentTarif", "dbo.AbonentTarifs");
            DropForeignKey("dbo.TarifAbonentTarifs", "Tarif_idTarif", "dbo.Tarifs");
            DropForeignKey("dbo.AbonentTarifs", "AbonentNumber", "dbo.Abonents");
            DropIndex("dbo.TarifAbonentTarifs", new[] { "AbonentTarif_idAbonentTarif" });
            DropIndex("dbo.TarifAbonentTarifs", new[] { "Tarif_idTarif" });
            DropIndex("dbo.AbonentTarifs", new[] { "AbonentNumber" });
            DropPrimaryKey("dbo.ServiceTarifs");
            DropTable("dbo.TarifAbonentTarifs");
            DropTable("dbo.AbonentTarifs");
            AddPrimaryKey("dbo.ServiceTarifs", new[] { "Tarif_idTarif", "Service_idService" });
            RenameTable(name: "dbo.ServiceTarifs", newName: "TarifServices");
        }
    }
}
