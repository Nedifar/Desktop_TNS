namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbonentEquipments",
                c => new
                    {
                        idAbonentEquipment = c.Int(nullable: false, identity: true),
                        serialNumber = c.String(maxLength: 128),
                        ports = c.String(),
                        speed = c.String(),
                    })
                .PrimaryKey(t => t.idAbonentEquipment)
                .ForeignKey("dbo.Equipments", t => t.serialNumber)
                .Index(t => t.serialNumber);
            
            CreateTable(
                "dbo.AccsesNetworks",
                c => new
                    {
                        idAccsesNetwork = c.Int(nullable: false, identity: true),
                        serialNumber = c.String(maxLength: 128),
                        ports = c.String(),
                        standart = c.String(),
                        frequince = c.String(),
                        interfaces = c.String(),
                        speed = c.String(),
                        location = c.String(),
                    })
                .PrimaryKey(t => t.idAccsesNetwork)
                .ForeignKey("dbo.Equipments", t => t.serialNumber)
                .Index(t => t.serialNumber);
            
            CreateTable(
                "dbo.Magistrals",
                c => new
                    {
                        idMagistral = c.Int(nullable: false, identity: true),
                        serialNumber = c.String(maxLength: 128),
                        frequince = c.String(),
                        zatuhanie = c.String(),
                        technology = c.String(),
                    })
                .PrimaryKey(t => t.idMagistral)
                .ForeignKey("dbo.Equipments", t => t.serialNumber)
                .Index(t => t.serialNumber);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        idLocation = c.Int(nullable: false, identity: true),
                        address = c.String(),
                        idMagistral = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idLocation)
                .ForeignKey("dbo.Magistrals", t => t.idMagistral, cascadeDelete: true)
                .Index(t => t.idMagistral);
            
            CreateTable(
                "dbo.AbonentEquipmentAbonentAddresses",
                c => new
                    {
                        AbonentEquipment_idAbonentEquipment = c.Int(nullable: false),
                        AbonentAddress_idAbonentAddress = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AbonentEquipment_idAbonentEquipment, t.AbonentAddress_idAbonentAddress })
                .ForeignKey("dbo.AbonentEquipments", t => t.AbonentEquipment_idAbonentEquipment, cascadeDelete: true)
                .ForeignKey("dbo.AbonentAddresses", t => t.AbonentAddress_idAbonentAddress, cascadeDelete: true)
                .Index(t => t.AbonentEquipment_idAbonentEquipment)
                .Index(t => t.AbonentAddress_idAbonentAddress);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "idMagistral", "dbo.Magistrals");
            DropForeignKey("dbo.Magistrals", "serialNumber", "dbo.Equipments");
            DropForeignKey("dbo.AccsesNetworks", "serialNumber", "dbo.Equipments");
            DropForeignKey("dbo.AbonentEquipments", "serialNumber", "dbo.Equipments");
            DropForeignKey("dbo.AbonentEquipmentAbonentAddresses", "AbonentAddress_idAbonentAddress", "dbo.AbonentAddresses");
            DropForeignKey("dbo.AbonentEquipmentAbonentAddresses", "AbonentEquipment_idAbonentEquipment", "dbo.AbonentEquipments");
            DropIndex("dbo.AbonentEquipmentAbonentAddresses", new[] { "AbonentAddress_idAbonentAddress" });
            DropIndex("dbo.AbonentEquipmentAbonentAddresses", new[] { "AbonentEquipment_idAbonentEquipment" });
            DropIndex("dbo.Locations", new[] { "idMagistral" });
            DropIndex("dbo.Magistrals", new[] { "serialNumber" });
            DropIndex("dbo.AccsesNetworks", new[] { "serialNumber" });
            DropIndex("dbo.AbonentEquipments", new[] { "serialNumber" });
            DropTable("dbo.AbonentEquipmentAbonentAddresses");
            DropTable("dbo.Locations");
            DropTable("dbo.Magistrals");
            DropTable("dbo.AccsesNetworks");
            DropTable("dbo.AbonentEquipments");
        }
    }
}
