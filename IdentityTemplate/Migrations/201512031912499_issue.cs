namespace IdentityTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class issue : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingID = c.Int(nullable: false, identity: true),
                        SKU = c.Int(nullable: false),
                        CustomerRating = c.Int(nullable: false),
                        AverageRating = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RatingID);
            
            CreateIndex("dbo.Ratings", "User_Id");
            CreateIndex("dbo.Ratings", "SKU");
            AddForeignKey("dbo.Ratings", "User_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Ratings", "SKU", "dbo.Books", "SKU", cascadeDelete: true);
        }
    }
}
