namespace IdentityTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingID = c.Int(nullable: false, identity: true),
                        SKU = c.Int(nullable: false),
                        CustomerRating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RatingID)
                .ForeignKey("dbo.Books", t => t.SKU, cascadeDelete: true)
                .Index(t => t.SKU);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        SKU = c.Int(nullable: false),
                        CustomerReview = c.String(),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Books", t => t.SKU, cascadeDelete: true)
                .Index(t => t.SKU);
            
            DropColumn("dbo.Books", "Rating");
            DropColumn("dbo.Books", "Active");
            DropColumn("dbo.Books", "Review");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Review", c => c.String());
            AddColumn("dbo.Books", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Books", "Rating", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reviews", "SKU", "dbo.Books");
            DropForeignKey("dbo.Ratings", "SKU", "dbo.Books");
            DropIndex("dbo.Reviews", new[] { "SKU" });
            DropIndex("dbo.Ratings", new[] { "SKU" });
            DropTable("dbo.Reviews");
            DropTable("dbo.Ratings");
        }
    }
}
