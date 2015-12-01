namespace IdentityTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditCards",
                c => new
                    {
                        CreditCardID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        CardName = c.String(nullable: false),
                        CardNumber = c.String(nullable: false),
                        CardType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreditCardID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            DropColumn("dbo.Customers", "CreditCard1");
            DropColumn("dbo.Customers", "CreditCard1Type");
            DropColumn("dbo.Customers", "CreditCard2");
            DropColumn("dbo.Customers", "CreditCard2Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CreditCard2Type", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "CreditCard2", c => c.String());
            AddColumn("dbo.Customers", "CreditCard1Type", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "CreditCard1", c => c.String(nullable: false));
            DropForeignKey("dbo.CreditCards", "CustomerID", "dbo.Customers");
            DropIndex("dbo.CreditCards", new[] { "CustomerID" });
            DropTable("dbo.CreditCards");
        }
    }
}
