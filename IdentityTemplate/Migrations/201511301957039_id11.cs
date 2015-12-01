namespace IdentityTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisterViewModels", "MI", c => c.String());
            AddColumn("dbo.AspNetUsers", "MI", c => c.String());
            AddColumn("dbo.AspNetUsers", "CreditCard1", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "CreditCard1Type", c => c.String());
            AddColumn("dbo.AspNetUsers", "CreditCard2", c => c.String());
            AddColumn("dbo.AspNetUsers", "CreditCard2Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CreditCard2Type");
            DropColumn("dbo.AspNetUsers", "CreditCard2");
            DropColumn("dbo.AspNetUsers", "CreditCard1Type");
            DropColumn("dbo.AspNetUsers", "CreditCard1");
            DropColumn("dbo.AspNetUsers", "MI");
            DropColumn("dbo.RegisterViewModels", "MI");
        }
    }
}
