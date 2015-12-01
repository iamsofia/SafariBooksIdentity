namespace IdentityTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identity5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        CouponID = c.String(nullable: false, maxLength: 20),
                        Active = c.Boolean(nullable: false),
                        FreeShipIf = c.Boolean(nullable: false),
                        FreeShipAll = c.Boolean(nullable: false),
                        DiscountTotal = c.Boolean(nullable: false),
                        Discount = c.Decimal(precision: 18, scale: 2),
                        OrderThreshold = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CouponID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Coupons");
        }
    }
}
