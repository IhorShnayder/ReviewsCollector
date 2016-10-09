namespace ReviewsCollector.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusToReview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "Status");
        }
    }
}
