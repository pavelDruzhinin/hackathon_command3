namespace Simplelife.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Categories", new[] { "UserId" });
            AlterColumn("dbo.Categories", "ParentId", c => c.Int());
            AlterColumn("dbo.Categories", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Categories", "UserId");
            AddForeignKey("dbo.Categories", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Categories", new[] { "UserId" });
            AlterColumn("dbo.Categories", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Categories", "ParentId", c => c.Int(nullable: true));
            CreateIndex("dbo.Categories", "UserId");
            AddForeignKey("dbo.Categories", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
