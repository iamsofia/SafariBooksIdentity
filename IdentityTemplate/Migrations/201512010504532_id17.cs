namespace IdentityTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CreditCards", "AppUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.CreditCards", "AppUser_Id");
            AddForeignKey("dbo.CreditCards", "AppUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditCards", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.CreditCards", new[] { "AppUser_Id" });
            DropColumn("dbo.CreditCards", "AppUser_Id");
        }
    }
}
