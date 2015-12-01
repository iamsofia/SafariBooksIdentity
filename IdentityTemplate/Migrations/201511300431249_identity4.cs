namespace IdentityTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identity4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CustomerType", c => c.Boolean());
            AddColumn("dbo.AspNetUsers", "ManagerType", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ManagerType");
            DropColumn("dbo.AspNetUsers", "CustomerType");
        }
    }
}
