namespace Simplelife.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCategories : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notes", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Notes", new[] { "Category_Id" });
            DropColumn("dbo.Notes", "Category_Id");
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Name = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Notes", "Category_Id", c => c.Int());
            CreateIndex("dbo.Notes", "Category_Id");
            CreateIndex("dbo.Categories", "ApplicationUser_Id");
            AddForeignKey("dbo.Notes", "Category_Id", "dbo.Categories", "Id");
            AddForeignKey("dbo.Categories", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
