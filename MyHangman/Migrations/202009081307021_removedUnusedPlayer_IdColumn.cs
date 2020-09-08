namespace MyHangman.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class removedUnusedPlayer_IdColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OpenHints", "Level_ID", "dbo.Levels");
            DropIndex("dbo.OpenHints", new[] { "Level_ID" });
            DropColumn("dbo.OpenHints", "Level_ID");
        }

        public override void Down()
        {
            AddColumn("dbo.OpenHints", "Level_ID", c => c.Int());
            CreateIndex("dbo.OpenHints", "Level_ID");
            AddForeignKey("dbo.OpenHints", "Level_ID", "dbo.Levels", "ID");
        }
    }
}