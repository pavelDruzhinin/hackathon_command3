namespace Simplelife.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class threeHoursToDeadline : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Objectives", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Objectives", "Type", c => c.Int(nullable: false));
        }
    }
}
