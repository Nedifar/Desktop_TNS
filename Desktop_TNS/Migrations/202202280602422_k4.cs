namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class k4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbonentPayments",
                c => new
                    {
                        idAbonentPayment = c.Int(nullable: false, identity: true),
                        datePayment = c.DateTime(nullable: false),
                        sumPayment = c.Double(nullable: false),
                        balans = c.Double(nullable: false),
                        dateBalans = c.DateTime(nullable: false),
                        arrears = c.Double(),
                        AbonentNumber = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.idAbonentPayment)
                .ForeignKey("dbo.Abonents", t => t.AbonentNumber)
                .Index(t => t.AbonentNumber);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AbonentPayments", "AbonentNumber", "dbo.Abonents");
            DropIndex("dbo.AbonentPayments", new[] { "AbonentNumber" });
            DropTable("dbo.AbonentPayments");
        }
    }
}
