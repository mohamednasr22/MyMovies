namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNameMemberType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MemberShipTypes", "NameType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MemberShipTypes", "NameType");
        }
    }
}
