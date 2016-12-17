namespace Simplelife.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TasksMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TagNotes", "TagId", "dbo.Tags");
            DropForeignKey("dbo.TagNotes", "NoteId", "dbo.Notes");
            DropForeignKey("dbo.Tags", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Tags", new[] { "UserId" });
            DropIndex("dbo.TagNotes", new[] { "TagId" });
            DropIndex("dbo.TagNotes", new[] { "NoteId" });
            CreateTable(
                "dbo.Checklists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Objective_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Objectives", t => t.Objective_Id)
                .Index(t => t.Objective_Id);
            
            CreateTable(
                "dbo.Objectives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            DropTable("dbo.Tags");
            DropTable("dbo.TagNotes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TagNotes",
                c => new
                    {
                        TagId = c.Int(nullable: false),
                        NoteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagId, t.NoteId });
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Objectives", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Checklists", "Objective_Id", "dbo.Objectives");
            DropIndex("dbo.Objectives", new[] { "UserId" });
            DropIndex("dbo.Checklists", new[] { "Objective_Id" });
            DropTable("dbo.Objectives");
            DropTable("dbo.Checklists");
            CreateIndex("dbo.TagNotes", "NoteId");
            CreateIndex("dbo.TagNotes", "TagId");
            CreateIndex("dbo.Tags", "UserId");
            AddForeignKey("dbo.Tags", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TagNotes", "NoteId", "dbo.Notes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TagNotes", "TagId", "dbo.Tags", "Id", cascadeDelete: true);
        }
    }
}
