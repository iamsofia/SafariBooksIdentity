namespace IdentityTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id13 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CreditCard1Type", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "CreditCard2Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "CreditCard2Type", c => c.String());
            AlterColumn("dbo.Customers", "CreditCard1Type", c => c.String());
        }
    }
}
