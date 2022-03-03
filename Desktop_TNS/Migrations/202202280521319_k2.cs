namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Services", "Tarif_idTarif", "dbo.Tarifs");
            DropIndex("dbo.Services", new[] { "Tarif_idTarif" });
            CreateTable(
                "dbo.TarifServices",
                c => new
                    {
                        Tarif_idTarif = c.Int(nullable: false),
                        Service_idService = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tarif_idTarif, t.Service_idService })
                .ForeignKey("dbo.Tarifs", t => t.Tarif_idTarif, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.Service_idService, cascadeDelete: true)
                .Index(t => t.Tarif_idTarif)
                .Index(t => t.Service_idService);
            
            DropColumn("dbo.Services", "Tarif_idTarif");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "Tarif_idTarif", c => c.Int());
            DropForeignKey("dbo.TarifServices", "Service_idService", "dbo.Services");
            DropForeignKey("dbo.TarifServices", "Tarif_idTarif", "dbo.Tarifs");
            DropIndex("dbo.TarifServices", new[] { "Service_idService" });
            DropIndex("dbo.TarifServices", new[] { "Tarif_idTarif" });
            DropTable("dbo.TarifServices");
            CreateIndex("dbo.Services", "Tarif_idTarif");
            AddForeignKey("dbo.Services", "Tarif_idTarif", "dbo.Tarifs", "idTarif");
        }
    }
}
