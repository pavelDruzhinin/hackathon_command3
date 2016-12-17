namespace Simplelife.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FIX : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Checklists", "Objective_Id", "dbo.Objectives");
            DropIndex("dbo.Checklists", new[] { "Objective_Id" });
            DropTable("dbo.Checklists");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Checklists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Objective_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Checklists", "Objective_Id");
            AddForeignKey("dbo.Checklists", "Objective_Id", "dbo.Objectives", "Id");
        }
    }
}
