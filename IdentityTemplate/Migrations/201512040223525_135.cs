namespace IdentityTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _135 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "CustomerReview", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "CustomerReview", c => c.String());
        }
    }
}
