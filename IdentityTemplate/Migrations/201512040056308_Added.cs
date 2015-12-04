namespace IdentityTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "AverageRating", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "AverageRating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "AverageRating");
            DropColumn("dbo.Ratings", "AverageRating");
        }
    }
}
