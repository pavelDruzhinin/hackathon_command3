namespace Simplelife.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(nullable: false),
                        Name = c.String(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Content = c.String(),
                        CreateData = c.DateTime(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)
                .Index(t => t.CategoryId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notes", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Notes", new[] { "UserId" });
            DropIndex("dbo.Notes", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "UserId" });
            DropTable("dbo.Notes");
            DropTable("dbo.Categories");
        }
    }
}
