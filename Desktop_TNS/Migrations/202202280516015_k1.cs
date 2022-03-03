namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tarifs",
                c => new
                    {
                        idTarif = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        condition = c.String(),
                        cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.idTarif);
            
            AddColumn("dbo.Services", "Tarif_idTarif", c => c.Int());
            CreateIndex("dbo.Services", "Tarif_idTarif");
            AddForeignKey("dbo.Services", "Tarif_idTarif", "dbo.Tarifs", "idTarif");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "Tarif_idTarif", "dbo.Tarifs");
            DropIndex("dbo.Services", new[] { "Tarif_idTarif" });
            DropColumn("dbo.Services", "Tarif_idTarif");
            DropTable("dbo.Tarifs");
        }
    }
}
