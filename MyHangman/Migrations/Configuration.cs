namespace MyHangman.Migrations
{
    using MyHangman.Data;
    using MyHangman.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyHangman.Data.GameDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

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
            Level gameLevelone = new Level
            {
                Riddle = "This is dummy level first riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.VeryEasy,
                OpenHints = new List<OpenHint>(),
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLeveltwo = new Level
            {
                Riddle = "This is dummy level second riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Easy,
                OpenHints = new List<OpenHint>(),
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelthree = new Level
            {
                Riddle = "This is dummy level third riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Medium,
                OpenHints = new List<OpenHint>(),
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfour = new Level
            {
                Riddle = "This is dummy level fourth riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Hard,
                OpenHints = new List<OpenHint>(),
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfifth = new Level
            {
                Riddle = "This is dummy level fifth riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.veryHard,
                OpenHints = new List<OpenHint>(),
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };

            context.Levels.Add(gameLevelone);
            context.Levels.Add(gameLeveltwo);
            context.Levels.Add(gameLevelthree);
            context.Levels.Add(gameLevelfour);
            context.Levels.Add(gameLevelfifth);
            context.SaveChanges();
        }
    }
}