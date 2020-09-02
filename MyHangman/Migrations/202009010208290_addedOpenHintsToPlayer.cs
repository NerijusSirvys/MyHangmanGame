namespace MyHangman.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOpenHintsToPlayer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OpenHints", "PlayerID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OpenHints", "PlayerID");
        }
    }
}
