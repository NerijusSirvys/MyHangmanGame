namespace MyHangman.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompleteLevels",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    LevelID = c.Int(nullable: false),
                    Player_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Players", t => t.Player_Id)
                .Index(t => t.Player_Id);

            CreateTable(
                "dbo.Hints",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Body = c.String(),
                    Level_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Levels", t => t.Level_ID)
                .Index(t => t.Level_ID);

            CreateTable(
                "dbo.Levels",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Riddle = c.String(),
                    Answer = c.String(),
                    Difficulty = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.OpenHints",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    HintID = c.Int(nullable: false),
                    Level_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Levels", t => t.Level_ID)
                .Index(t => t.Level_ID);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.Roles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Players",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    GameScore = c.Int(nullable: false),
                    GoldenCoins = c.Int(nullable: false),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.Claims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.Logins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Players", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Roles", "UserId", "dbo.Players");
            DropForeignKey("dbo.Logins", "UserId", "dbo.Players");
            DropForeignKey("dbo.CompleteLevels", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.Claims", "UserId", "dbo.Players");
            DropForeignKey("dbo.Roles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.OpenHints", "Level_ID", "dbo.Levels");
            DropForeignKey("dbo.Hints", "Level_ID", "dbo.Levels");
            DropIndex("dbo.Logins", new[] { "UserId" });
            DropIndex("dbo.Claims", new[] { "UserId" });
            DropIndex("dbo.Players", "UserNameIndex");
            DropIndex("dbo.Roles", new[] { "RoleId" });
            DropIndex("dbo.Roles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.OpenHints", new[] { "Level_ID" });
            DropIndex("dbo.Hints", new[] { "Level_ID" });
            DropIndex("dbo.CompleteLevels", new[] { "Player_Id" });
            DropTable("dbo.Logins");
            DropTable("dbo.Claims");
            DropTable("dbo.Players");
            DropTable("dbo.Roles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.OpenHints");
            DropTable("dbo.Levels");
            DropTable("dbo.Hints");
            DropTable("dbo.CompleteLevels");
        }
    }
}