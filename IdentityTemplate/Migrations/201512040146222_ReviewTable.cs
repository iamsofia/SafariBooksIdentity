namespace IdentityTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "CustomerRating", c => c.Int(nullable: false));
            DropColumn("dbo.Reviews", "AverageRating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "AverageRating", c => c.Int(nullable: false));
            DropColumn("dbo.Reviews", "CustomerRating");
        }
    }
}
