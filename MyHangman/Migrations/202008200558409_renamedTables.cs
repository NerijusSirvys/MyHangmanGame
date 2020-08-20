namespace MyHangman.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class renamedTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Roles", newName: "UserRoles");
            RenameTable(name: "dbo.AspNetRoles", newName: "Roles");
            RenameTable(name: "dbo.Claims", newName: "UserClaims");
            RenameTable(name: "dbo.Logins", newName: "UserLogins");
        }

        public override void Down()
        {
            RenameTable(name: "dbo.UserLogins", newName: "Logins");
            RenameTable(name: "dbo.UserClaims", newName: "Claims");
            RenameTable(name: "dbo.UserRoles", newName: "Roles");
            RenameTable(name: "dbo.Roles", newName: "AspNetRoles");
        }
    }
}