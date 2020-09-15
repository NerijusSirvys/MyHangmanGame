namespace MyHangman.Migrations
{
    using MyHangman.Data;
    using MyHangman.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.IO;
    using MyHangman.Enums;

    internal sealed class Configuration : DbMigrationsConfiguration<MyHangman.Data.GameDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private const string veryEasyLevelsPath = @"Resource\VeryEasyLevels.txt";
        private const string easyLevelsPath = @"Resource\EasyLevels.txt";
        private const string mediumLevelsPath = @"Resource\MediumLevels.txt";
        private const string hardLevelsPath = @"Resource\HardLevels.txt";

        protected override void Seed(MyHangman.Data.GameDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            List<Level> levels = context.Levels.ToList();

            if (levels.Count == 0)
            {
                PopulateWithDummyData(context);
            }
        }

        private void PopulateWithDummyData(GameDbContext context)
        {
        

            TransferDataFromTextFileToDB(context, veryEasyLevelsPath, LevelDifficulty.VeryEasy);
            TransferDataFromTextFileToDB(context, easyLevelsPath, LevelDifficulty.Easy);
            TransferDataFromTextFileToDB(context, mediumLevelsPath, LevelDifficulty.Medium);
            TransferDataFromTextFileToDB(context, hardLevelsPath, LevelDifficulty.Hard);

            context.SaveChanges();
        }

        private static void TransferDataFromTextFileToDB(GameDbContext context, string veryEasyLevelsPath, LevelDifficulty levelDifficulty)
        {
            List<string> lines = File.ReadAllLines(veryEasyLevelsPath).ToList();

            foreach (var line in lines)
            {
                string[] entries = line.Split(',');

                if (entries.Length == 5)
                {
                    Level veryEasyLevel = new Level
                    {
                        Answer = entries[0],
                        Riddle = entries[1],
                        Difficulty = levelDifficulty,
                        Hints = new List<Hint>
                        {
                            new Hint{Body = entries[2] },
                            new Hint{Body = entries[3] },
                            new Hint{Body = entries[4] }
                        }
                    };

                    context.Levels.Add(veryEasyLevel);
                }
            }
        }
    }
}