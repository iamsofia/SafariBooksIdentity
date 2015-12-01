namespace IdentityTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id19 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CreditCards", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Email", "dbo.RegisterViewModels");
            DropForeignKey("dbo.Employees", "Email", "dbo.RegisterViewModels");
            DropIndex("dbo.CreditCards", new[] { "Customer_CustomerID" });
            DropIndex("dbo.Customers", new[] { "Email" });
            DropIndex("dbo.Employees", new[] { "Email" });
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        SKU = c.Int(nullable: false),
                        CouponID = c.String(maxLength: 20),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Books", t => t.SKU, cascadeDelete: true)
                .ForeignKey("dbo.Coupons", t => t.CouponID)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.SKU)
                .Index(t => t.CouponID)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Reorders",
                c => new
                    {
                        ReorderID = c.Int(nullable: false, identity: true),
                        SKU = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ReorderID)
                .ForeignKey("dbo.Books", t => t.SKU, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.SKU)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Books", "Order_OrderID", c => c.Int());
            AddColumn("dbo.Ratings", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Reviews", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Books", "Order_OrderID");
            CreateIndex("dbo.Ratings", "User_Id");
            CreateIndex("dbo.Reviews", "User_Id");
            AddForeignKey("dbo.Ratings", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Reviews", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Books", "Order_OrderID", "dbo.Orders", "OrderID");
            DropColumn("dbo.CreditCards", "Customer_CustomerID");
            DropTable("dbo.Customers");
            DropTable("dbo.Employees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            AddColumn("dbo.CreditCards", "Customer_CustomerID", c => c.Int());
            DropForeignKey("dbo.Reorders", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reorders", "SKU", "dbo.Books");
            DropForeignKey("dbo.Orders", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "CouponID", "dbo.Coupons");
            DropForeignKey("dbo.Books", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.Orders", "SKU", "dbo.Books");
            DropForeignKey("dbo.Reviews", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reorders", new[] { "User_Id" });
            DropIndex("dbo.Reorders", new[] { "SKU" });
            DropIndex("dbo.Orders", new[] { "User_Id" });
            DropIndex("dbo.Orders", new[] { "CouponID" });
            DropIndex("dbo.Orders", new[] { "SKU" });
            DropIndex("dbo.Reviews", new[] { "User_Id" });
            DropIndex("dbo.Ratings", new[] { "User_Id" });
            DropIndex("dbo.Books", new[] { "Order_OrderID" });
            DropColumn("dbo.Reviews", "User_Id");
            DropColumn("dbo.Ratings", "User_Id");
            DropColumn("dbo.Books", "Order_OrderID");
            DropTable("dbo.Reorders");
            DropTable("dbo.Orders");
            CreateIndex("dbo.Employees", "Email");
            CreateIndex("dbo.Customers", "Email");
            CreateIndex("dbo.CreditCards", "Customer_CustomerID");
            AddForeignKey("dbo.Employees", "Email", "dbo.RegisterViewModels", "Email");
            AddForeignKey("dbo.Customers", "Email", "dbo.RegisterViewModels", "Email");
            AddForeignKey("dbo.CreditCards", "Customer_CustomerID", "dbo.Customers", "CustomerID");
        }
    }
}
