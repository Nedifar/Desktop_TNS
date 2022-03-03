namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CRMs", "idService", "dbo.Services");
            DropIndex("dbo.CRMs", new[] { "idService" });
            AlterColumn("dbo.CRMs", "idService", c => c.Int());
            CreateIndex("dbo.CRMs", "idService");
            AddForeignKey("dbo.CRMs", "idService", "dbo.Services", "idService");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CRMs", "idService", "dbo.Services");
            DropIndex("dbo.CRMs", new[] { "idService" });
            AlterColumn("dbo.CRMs", "idService", c => c.Int(nullable: false));
            CreateIndex("dbo.CRMs", "idService");
            AddForeignKey("dbo.CRMs", "idService", "dbo.Services", "idService", cascadeDelete: true);
        }
    }
}
