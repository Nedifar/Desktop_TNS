namespace Desktop_TNS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "lastName", c => c.String());
            AddColumn("dbo.Employees", "firstName", c => c.String());
            AddColumn("dbo.Employees", "middleName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "middleName");
            DropColumn("dbo.Employees", "firstName");
            DropColumn("dbo.Employees", "lastName");
        }
    }
}
