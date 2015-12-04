namespace IdentityTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewClassUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "ReviewApproval", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "ReviewApproval");
        }
    }
}
