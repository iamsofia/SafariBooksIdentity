namespace IdentityTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 128),
                        SKU = c.Int(nullable: false),
                        CreditCard1 = c.String(nullable: false),
                        CreditCard1Type = c.String(),
                        CreditCard2 = c.String(),
                        CreditCard2Type = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.Books", t => t.SKU, cascadeDelete: true)
                .ForeignKey("dbo.RegisterViewModels", t => t.Email)
                .Index(t => t.Email)
                .Index(t => t.SKU);
            
            CreateTable(
                "dbo.RegisterViewModels",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                        FName = c.String(nullable: false),
                        LName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.Int(nullable: false),
                        Phone = c.String(nullable: false),
                        IsManager = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Email);
            
            DropColumn("dbo.AspNetUsers", "CreditCard1");
            DropColumn("dbo.AspNetUsers", "CustomerType");
            DropColumn("dbo.AspNetUsers", "ManagerType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ManagerType", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "CustomerType", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "CreditCard1", c => c.String());
            DropForeignKey("dbo.Customers", "Email", "dbo.RegisterViewModels");
            DropForeignKey("dbo.Customers", "SKU", "dbo.Books");
            DropIndex("dbo.Customers", new[] { "SKU" });
            DropIndex("dbo.Customers", new[] { "Email" });
            DropTable("dbo.RegisterViewModels");
            DropTable("dbo.Customers");
        }
    }
}
