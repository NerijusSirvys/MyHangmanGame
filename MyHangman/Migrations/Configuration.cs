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
            Level gameLevelone1 = new Level
            {
                Riddle = "This is dummy level first 1 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.VeryEasy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelone2 = new Level
            {
                Riddle = "This is dummy level first 2 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.VeryEasy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelone3 = new Level
            {
                Riddle = "This is dummy level first 3 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.VeryEasy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelone4 = new Level
            {
                Riddle = "This is dummy level first 4 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.VeryEasy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelone5 = new Level
            {
                Riddle = "This is dummy level first 5 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.VeryEasy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelone6 = new Level
            {
                Riddle = "This is dummy level first 6 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.VeryEasy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelone7 = new Level
            {
                Riddle = "This is dummy level first 7 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.VeryEasy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelone8 = new Level
            {
                Riddle = "This is dummy level first 8 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.VeryEasy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelone9 = new Level
            {
                Riddle = "This is dummy level first 9 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.VeryEasy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelone10 = new Level
            {
                Riddle = "This is dummy level first 10 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.VeryEasy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };

            Level gameLeveltwo1 = new Level
            {
                Riddle = "This is dummy level second 1 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Easy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLeveltwo2 = new Level
            {
                Riddle = "This is dummy level second 2 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Easy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLeveltwo3 = new Level
            {
                Riddle = "This is dummy level second 3 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Easy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLeveltwo4 = new Level
            {
                Riddle = "This is dummy level second 4 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Easy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLeveltwo5 = new Level
            {
                Riddle = "This is dummy level second 5 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Easy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLeveltwo6 = new Level
            {
                Riddle = "This is dummy level second 6 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Easy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLeveltwo7 = new Level
            {
                Riddle = "This is dummy level second 7 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Easy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLeveltwo8 = new Level
            {
                Riddle = "This is dummy level second 8 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Easy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLeveltwo9 = new Level
            {
                Riddle = "This is dummy level second 9 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Easy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLeveltwo10 = new Level
            {
                Riddle = "This is dummy level second 10 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Easy,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };

            Level gameLevelthree1 = new Level
            {
                Riddle = "This is dummy level third 1 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Medium,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelthree2 = new Level
            {
                Riddle = "This is dummy level third 2 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Medium,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelthree3 = new Level
            {
                Riddle = "This is dummy level third 3 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Medium,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelthree4 = new Level
            {
                Riddle = "This is dummy level third 4 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Medium,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelthree5 = new Level
            {
                Riddle = "This is dummy level third 5 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Medium,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelthree6 = new Level
            {
                Riddle = "This is dummy level third 6 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Medium,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelthree7 = new Level
            {
                Riddle = "This is dummy level third 7 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Medium,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelthree8 = new Level
            {
                Riddle = "This is dummy level third 8 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Medium,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelthree9 = new Level
            {
                Riddle = "This is dummy level third 9 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Medium,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelthree10 = new Level
            {
                Riddle = "This is dummy level third 10 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Medium,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };

            Level gameLevelfour1 = new Level
            {
                Riddle = "This is dummy level fourth 1 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Hard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfour2 = new Level
            {
                Riddle = "This is dummy level fourth 2 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Hard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfour3 = new Level
            {
                Riddle = "This is dummy level fourth 3 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Hard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfour4 = new Level
            {
                Riddle = "This is dummy level fourth 4 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Hard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfour5 = new Level
            {
                Riddle = "This is dummy level fourth 5 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Hard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfour6 = new Level
            {
                Riddle = "This is dummy level fourth 6 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Hard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfour7 = new Level
            {
                Riddle = "This is dummy level fourth 7 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Hard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfour8 = new Level
            {
                Riddle = "This is dummy level fourth 8 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Hard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfour9 = new Level
            {
                Riddle = "This is dummy level fourth 9 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Hard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfour10 = new Level
            {
                Riddle = "This is dummy level fourth 10 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.Hard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };

            Level gameLevelfifth1 = new Level
            {
                Riddle = "This is dummy level fifth 1 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.veryHard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfifth2 = new Level
            {
                Riddle = "This is dummy level fifth 2 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.veryHard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfifth3 = new Level
            {
                Riddle = "This is dummy level fifth 3 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.veryHard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfifth4 = new Level
            {
                Riddle = "This is dummy level fifth 4 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.veryHard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfifth5 = new Level
            {
                Riddle = "This is dummy level fifth 5 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.veryHard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfifth6 = new Level
            {
                Riddle = "This is dummy level fifth 6 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.veryHard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfifth7 = new Level
            {
                Riddle = "This is dummy level fifth 7 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.veryHard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfifth8 = new Level
            {
                Riddle = "This is dummy level fifth 8 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.veryHard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfifth9 = new Level
            {
                Riddle = "This is dummy level fifth 9 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.veryHard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };
            Level gameLevelfifth10 = new Level
            {
                Riddle = "This is dummy level fifth 10 riddle",
                Answer = "dummyAnswer",
                Difficulty = Enums.LevelDifficulty.veryHard,
                Hints = new List<Hint>
                {
                    new Hint{Body = "Dummy hint one"},
                    new Hint{Body = "Dummy hint two"},
                    new Hint{Body = "Dummy hint three"}
                }
            };


            context.Levels.Add(gameLevelone1);
            context.Levels.Add(gameLevelone2);
            context.Levels.Add(gameLevelone3);
            context.Levels.Add(gameLevelone4);
            context.Levels.Add(gameLevelone5);
            context.Levels.Add(gameLevelone6);
            context.Levels.Add(gameLevelone7);
            context.Levels.Add(gameLevelone8);
            context.Levels.Add(gameLevelone9);
            context.Levels.Add(gameLevelone10);

            context.Levels.Add(gameLeveltwo1);
            context.Levels.Add(gameLeveltwo2);
            context.Levels.Add(gameLeveltwo3);
            context.Levels.Add(gameLeveltwo4);
            context.Levels.Add(gameLeveltwo5);
            context.Levels.Add(gameLeveltwo6);
            context.Levels.Add(gameLeveltwo7);
            context.Levels.Add(gameLeveltwo8);
            context.Levels.Add(gameLeveltwo9);
            context.Levels.Add(gameLeveltwo10);


            context.Levels.Add(gameLevelthree1);
            context.Levels.Add(gameLevelthree2);
            context.Levels.Add(gameLevelthree3);
            context.Levels.Add(gameLevelthree4);
            context.Levels.Add(gameLevelthree5);
            context.Levels.Add(gameLevelthree6);
            context.Levels.Add(gameLevelthree7);
            context.Levels.Add(gameLevelthree8);
            context.Levels.Add(gameLevelthree9);
            context.Levels.Add(gameLevelthree10);


            context.Levels.Add(gameLevelfour1);
            context.Levels.Add(gameLevelfour2);
            context.Levels.Add(gameLevelfour3);
            context.Levels.Add(gameLevelfour4);
            context.Levels.Add(gameLevelfour5);
            context.Levels.Add(gameLevelfour6);
            context.Levels.Add(gameLevelfour7);
            context.Levels.Add(gameLevelfour8);
            context.Levels.Add(gameLevelfour9);
            context.Levels.Add(gameLevelfour10);


            context.Levels.Add(gameLevelfifth1);
            context.Levels.Add(gameLevelfifth2);
            context.Levels.Add(gameLevelfifth3);
            context.Levels.Add(gameLevelfifth4);
            context.Levels.Add(gameLevelfifth5);
            context.Levels.Add(gameLevelfifth6);
            context.Levels.Add(gameLevelfifth7);
            context.Levels.Add(gameLevelfifth8);
            context.Levels.Add(gameLevelfifth9);
            context.Levels.Add(gameLevelfifth10);


            context.SaveChanges();
        }
    }
}