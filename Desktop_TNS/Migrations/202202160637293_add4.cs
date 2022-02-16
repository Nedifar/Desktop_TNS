namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add4 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ContractServices", newName: "ServiceContracts");
            DropForeignKey("dbo.Contracts", "AbonentNumber", "dbo.Abonents");
            DropIndex("dbo.Contracts", new[] { "AbonentNumber" });
            DropPrimaryKey("dbo.ServiceContracts");
            AddColumn("dbo.Abonents", "idContract", c => c.String(maxLength: 128));
            AddColumn("dbo.Abonents", "passport_n", c => c.String());
            AlterColumn("dbo.Contracts", "dateClosed", c => c.DateTime());
            AddPrimaryKey("dbo.ServiceContracts", new[] { "Service_idService", "Contract_idContract" });
            CreateIndex("dbo.Abonents", "idContract");
            AddForeignKey("dbo.Abonents", "idContract", "dbo.Contracts", "idContract");
            DropColumn("dbo.Abonents", "passporn_n");
            DropColumn("dbo.Contracts", "AbonentNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contracts", "AbonentNumber", c => c.String(maxLength: 128));
            AddColumn("dbo.Abonents", "passporn_n", c => c.String());
            DropForeignKey("dbo.Abonents", "idContract", "dbo.Contracts");
            DropIndex("dbo.Abonents", new[] { "idContract" });
            DropPrimaryKey("dbo.ServiceContracts");
            AlterColumn("dbo.Contracts", "dateClosed", c => c.DateTime(nullable: false));
            DropColumn("dbo.Abonents", "passport_n");
            DropColumn("dbo.Abonents", "idContract");
            AddPrimaryKey("dbo.ServiceContracts", new[] { "Contract_idContract", "Service_idService" });
            CreateIndex("dbo.Contracts", "AbonentNumber");
            AddForeignKey("dbo.Contracts", "AbonentNumber", "dbo.Abonents", "AbonentNumber");
            RenameTable(name: "dbo.ServiceContracts", newName: "ContractServices");
        }
    }
}
