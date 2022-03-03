
namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class r1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        idEvent = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        idEmployee = c.Int(),
                        NumberCRM = c.String(maxLength: 128),
                        begin = c.DateTime(nullable: false),
                        end = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idEvent)
                .ForeignKey("dbo.CRMs", t => t.NumberCRM)
                .ForeignKey("dbo.Employees", t => t.idEmployee)
                .ForeignKey("dbo.DateTables", t => t.date, cascadeDelete: true)
                .Index(t => t.date)
                .Index(t => t.idEmployee)
                .Index(t => t.NumberCRM);
            
            CreateTable(
                "dbo.DateTables",
                c => new
                    {
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.date);
            
            CreateTable(
                "dbo.EmployeeDateTables",
                c => new
                    {
                        Employee_idEmployee = c.Int(nullable: false),
                        DateTable_date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_idEmployee, t.DateTable_date })
                .ForeignKey("dbo.Employees", t => t.Employee_idEmployee, cascadeDelete: true)
                .ForeignKey("dbo.DateTables", t => t.DateTable_date, cascadeDelete: true)
                .Index(t => t.Employee_idEmployee)
                .Index(t => t.DateTable_date);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "date", "dbo.DateTables");
            DropForeignKey("dbo.Events", "idEmployee", "dbo.Employees");
            DropForeignKey("dbo.EmployeeDateTables", "DateTable_date", "dbo.DateTables");
            DropForeignKey("dbo.EmployeeDateTables", "Employee_idEmployee", "dbo.Employees");
            DropForeignKey("dbo.Events", "NumberCRM", "dbo.CRMs");
            DropIndex("dbo.EmployeeDateTables", new[] { "DateTable_date" });
            DropIndex("dbo.EmployeeDateTables", new[] { "Employee_idEmployee" });
            DropIndex("dbo.Events", new[] { "NumberCRM" });
            DropIndex("dbo.Events", new[] { "idEmployee" });
            DropIndex("dbo.Events", new[] { "date" });
            DropTable("dbo.EmployeeDateTables");
            DropTable("dbo.DateTables");
            DropTable("dbo.Events");
        }
    }
}
