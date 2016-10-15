namespace ReviewsCollector.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BindReviewToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "AuthorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Reviews", "AuthorId");
            AddForeignKey("dbo.Reviews", "AuthorId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Reviews", new[] { "AuthorId" });
            DropColumn("dbo.Reviews", "AuthorId");
        }
    }
}
