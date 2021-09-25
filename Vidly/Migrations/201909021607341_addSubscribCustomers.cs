namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSubscribCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribToNewsLetter");
        }
    }
}
