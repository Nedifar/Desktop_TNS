namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbonentAddresses",
                c => new
                    {
                        idAbonentAddress = c.String(nullable: false, maxLength: 128),
                        prefixCode = c.String(),
                        idRaion = c.Int(nullable: false),
                        prefix = c.String(),
                        house = c.String(),
                    })
                .PrimaryKey(t => t.idAbonentAddress)
                .ForeignKey("dbo.Raions", t => t.idRaion, cascadeDelete: true)
                .Index(t => t.idRaion);
            
            CreateTable(
                "dbo.Abonents",
                c => new
                    {
                        AbonentNumber = c.String(nullable: false, maxLength: 128),
                        lastName = c.String(),
                        firstName = c.String(),
                        middleName = c.String(),
                        gender = c.String(),
                        birth = c.DateTime(nullable: false),
                        phone = c.String(),
                        email = c.String(),
                        addressPropiski = c.String(),
                        idAbonentAddress = c.String(maxLength: 128),
                        passport_s = c.String(),
                        passporn_n = c.String(),
                        code = c.String(),
                        issue = c.String(),
                        dateIssue = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AbonentNumber)
                .ForeignKey("dbo.AbonentAddresses", t => t.idAbonentAddress)
                .Index(t => t.idAbonentAddress);
            
            CreateTable(
                "dbo.CRMs",
                c => new
                    {
                        NumberCRM = c.String(nullable: false, maxLength: 128),
                        dateCreated = c.DateTime(nullable: false),
                        AbonentNumber = c.String(maxLength: 128),
                        idService = c.Int(nullable: false),
                        serviceType = c.String(),
                        serviceView = c.String(),
                        status = c.String(),
                        equipmentType = c.String(),
                        problem = c.String(),
                        dateClosed = c.DateTime(nullable: false),
                        typeProblem = c.String(),
                    })
                .PrimaryKey(t => t.NumberCRM)
                .ForeignKey("dbo.Abonents", t => t.AbonentNumber)
                .ForeignKey("dbo.Services", t => t.idService, cascadeDelete: true)
                .Index(t => t.AbonentNumber)
                .Index(t => t.idService);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        idService = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.idService);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        idContract = c.String(nullable: false, maxLength: 128),
                        AbonentNumber = c.String(maxLength: 128),
                        dateConclude = c.DateTime(nullable: false),
                        typeContract = c.String(),
                        reasin = c.String(),
                        lc = c.String(),
                        dateClosed = c.DateTime(nullable: false),
                        description = c.String(),
                        serialNumber = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.idContract)
                .ForeignKey("dbo.Abonents", t => t.AbonentNumber)
                .ForeignKey("dbo.Equipments", t => t.serialNumber)
                .Index(t => t.AbonentNumber)
                .Index(t => t.serialNumber);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        SerialNumber = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        idEquipmentType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SerialNumber)
                .ForeignKey("dbo.EquipmentTypes", t => t.idEquipmentType, cascadeDelete: true)
                .Index(t => t.idEquipmentType);
            
            CreateTable(
                "dbo.EquipmentTypes",
                c => new
                    {
                        idEquipmentType = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.idEquipmentType);
            
            CreateTable(
                "dbo.Raions",
                c => new
                    {
                        idRaion = c.Int(nullable: false, identity: true),
                        area = c.Double(nullable: false),
                        population = c.Double(nullable: false),
                        countMentro = c.Int(nullable: false),
                        typeBuild = c.String(),
                    })
                .PrimaryKey(t => t.idRaion);
            
            CreateTable(
                "dbo.EmployeeInformations",
                c => new
                    {
                        idEmployeeInformation = c.Int(nullable: false, identity: true),
                        info = c.String(),
                        idEmployeeType = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idEmployeeInformation)
                .ForeignKey("dbo.EmployeeTypes", t => t.idEmployeeType, cascadeDelete: true)
                .Index(t => t.idEmployeeType);
            
            CreateTable(
                "dbo.ContractServices",
                c => new
                    {
                        Contract_idContract = c.String(nullable: false, maxLength: 128),
                        Service_idService = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Contract_idContract, t.Service_idService })
                .ForeignKey("dbo.Contracts", t => t.Contract_idContract, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.Service_idService, cascadeDelete: true)
                .Index(t => t.Contract_idContract)
                .Index(t => t.Service_idService);
            
            AddColumn("dbo.Employees", "imagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeInformations", "idEmployeeType", "dbo.EmployeeTypes");
            DropForeignKey("dbo.AbonentAddresses", "idRaion", "dbo.Raions");
            DropForeignKey("dbo.CRMs", "idService", "dbo.Services");
            DropForeignKey("dbo.ContractServices", "Service_idService", "dbo.Services");
            DropForeignKey("dbo.ContractServices", "Contract_idContract", "dbo.Contracts");
            DropForeignKey("dbo.Equipments", "idEquipmentType", "dbo.EquipmentTypes");
            DropForeignKey("dbo.Contracts", "serialNumber", "dbo.Equipments");
            DropForeignKey("dbo.Contracts", "AbonentNumber", "dbo.Abonents");
            DropForeignKey("dbo.CRMs", "AbonentNumber", "dbo.Abonents");
            DropForeignKey("dbo.Abonents", "idAbonentAddress", "dbo.AbonentAddresses");
            DropIndex("dbo.ContractServices", new[] { "Service_idService" });
            DropIndex("dbo.ContractServices", new[] { "Contract_idContract" });
            DropIndex("dbo.EmployeeInformations", new[] { "idEmployeeType" });
            DropIndex("dbo.Equipments", new[] { "idEquipmentType" });
            DropIndex("dbo.Contracts", new[] { "serialNumber" });
            DropIndex("dbo.Contracts", new[] { "AbonentNumber" });
            DropIndex("dbo.CRMs", new[] { "idService" });
            DropIndex("dbo.CRMs", new[] { "AbonentNumber" });
            DropIndex("dbo.Abonents", new[] { "idAbonentAddress" });
            DropIndex("dbo.AbonentAddresses", new[] { "idRaion" });
            DropColumn("dbo.Employees", "imagePath");
            DropTable("dbo.ContractServices");
            DropTable("dbo.EmployeeInformations");
            DropTable("dbo.Raions");
            DropTable("dbo.EquipmentTypes");
            DropTable("dbo.Equipments");
            DropTable("dbo.Contracts");
            DropTable("dbo.Services");
            DropTable("dbo.CRMs");
            DropTable("dbo.Abonents");
            DropTable("dbo.AbonentAddresses");
        }
    }
}
