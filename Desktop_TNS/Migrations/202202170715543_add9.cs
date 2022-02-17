namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add9 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CRMs", "dateClosed", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CRMs", "dateClosed", c => c.DateTime(nullable: false));
        }
    }
}
