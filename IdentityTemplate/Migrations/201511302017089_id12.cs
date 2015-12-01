namespace IdentityTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MInitial", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "MInitial");
        }
    }
}
