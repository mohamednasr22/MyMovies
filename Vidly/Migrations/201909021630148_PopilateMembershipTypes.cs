namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopilateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MemberShipTypes (Id,SignupFee,DurationInMonth,DiscountRate) VALUES (1,0,0,0)");
            Sql("INSERT INTO MemberShipTypes (Id,SignupFee,DurationInMonth,DiscountRate) VALUES (2,2,3,4)");
            Sql("INSERT INTO MemberShipTypes (Id,SignupFee,DurationInMonth,DiscountRate) VALUES (3,5,7,6)");
            Sql("INSERT INTO MemberShipTypes (Id,SignupFee,DurationInMonth,DiscountRate) VALUES (4,99,22,44)");
        }

        public override void Down()
        {
        }
    }
}
