namespace IdentityTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id121 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "CreditCard1");
            DropColumn("dbo.AspNetUsers", "CreditCard1Type");
            DropColumn("dbo.AspNetUsers", "CreditCard2");
            DropColumn("dbo.AspNetUsers", "CreditCard2Type");
            DropColumn("dbo.AspNetUsers", "MInitial");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "MInitial", c => c.String());
            AddColumn("dbo.AspNetUsers", "CreditCard2Type", c => c.String());
            AddColumn("dbo.AspNetUsers", "CreditCard2", c => c.String());
            AddColumn("dbo.AspNetUsers", "CreditCard1Type", c => c.String());
            AddColumn("dbo.AspNetUsers", "CreditCard1", c => c.String(nullable: false));
        }
    }
}
