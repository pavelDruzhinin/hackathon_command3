namespace Simplelife.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TagsAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Notes", new[] { "CategoryId" });
            RenameColumn(table: "dbo.Categories", name: "UserId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Notes", name: "CategoryId", newName: "Category_Id");
            RenameIndex(table: "dbo.Categories", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
            
            AlterColumn("dbo.Notes", "Category_Id", c => c.Int());
            CreateIndex("dbo.Notes", "Category_Id");
            AddForeignKey("dbo.Notes", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Tags", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TagNotes", "NoteId", "dbo.Notes");
            DropForeignKey("dbo.TagNotes", "TagId", "dbo.Tags");
            DropIndex("dbo.TagNotes", new[] { "NoteId" });
            DropIndex("dbo.TagNotes", new[] { "TagId" });
            DropIndex("dbo.Tags", new[] { "UserId" });
            DropIndex("dbo.Notes", new[] { "Category_Id" });
            AlterColumn("dbo.Notes", "Category_Id", c => c.Int(nullable: false));
            DropTable("dbo.TagNotes");
            DropTable("dbo.Tags");
            RenameIndex(table: "dbo.Categories", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.Notes", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Categories", name: "ApplicationUser_Id", newName: "UserId");
            CreateIndex("dbo.Notes", "CategoryId");
            AddForeignKey("dbo.Notes", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
