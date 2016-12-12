namespace Simplelife.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagsAdded : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "Tags");
            DropForeignKey("dbo.Notes", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Tags", new[] { "UserId" });
            DropIndex("dbo.Notes", new[] { "CategoryId" });
            CreateTable(
                "dbo.TagNotes",
                c => new
                    {
                        TagId = c.Int(nullable: false),
                        NoteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagId, t.NoteId })
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.Notes", t => t.NoteId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.NoteId);
            
            AlterColumn("dbo.Tags", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Tags", "UserId");
            AddForeignKey("dbo.Tags", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Tags", "ParentId");
            DropColumn("dbo.Notes", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Tags", "ParentId", c => c.Int());
            DropForeignKey("dbo.Tags", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TagNotes", "NoteId", "dbo.Notes");
            DropForeignKey("dbo.TagNotes", "TagId", "dbo.Tags");
            DropIndex("dbo.TagNotes", new[] { "NoteId" });
            DropIndex("dbo.TagNotes", new[] { "TagId" });
            DropIndex("dbo.Tags", new[] { "UserId" });
            AlterColumn("dbo.Tags", "UserId", c => c.String(maxLength: 128));
            DropTable("dbo.TagNotes");
            CreateIndex("dbo.Notes", "CategoryId");
            CreateIndex("dbo.Tags", "UserId");
            AddForeignKey("dbo.Categories", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Notes", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Tags", newName: "Categories");
        }
    }
}
