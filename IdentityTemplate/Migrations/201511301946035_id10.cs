namespace IdentityTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "SKU", "dbo.Books");
            DropIndex("dbo.Customers", new[] { "SKU" });
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.RegisterViewModels", t => t.Email)
                .Index(t => t.Email);
            
            DropColumn("dbo.Customers", "SKU");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "SKU", c => c.Int(nullable: false));
            DropForeignKey("dbo.Employees", "Email", "dbo.RegisterViewModels");
            DropIndex("dbo.Employees", new[] { "Email" });
            DropTable("dbo.Employees");
            CreateIndex("dbo.Customers", "SKU");
            AddForeignKey("dbo.Customers", "SKU", "dbo.Books", "SKU", cascadeDelete: true);
        }
    }
}
