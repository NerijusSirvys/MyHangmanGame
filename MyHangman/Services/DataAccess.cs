using MyHangman.Data;
using MyHangman.Enums;
using MyHangman.Models;
using System.Data.Entity;
using System.Linq;

namespace MyHangman.Services
{
    public class DataAccess
    {
        private readonly GameDbContext context;

        public DataAccess()
        {
            context = new GameDbContext();
        }

        public int GetNumberOfLevels()
        {
            return context.Levels.Count();
        }

        public Player GetPlayerByID(string userID)
        {
            return context.Users.Include(x => x.CompleteLevels).Where(x => x.Id == userID).FirstOrDefault();
        }

        public Level GetGameLevelByDifficulty(LevelDifficulty levelDifficulty)
        {
            return context.Levels.Include(x => x.Hints)
                                        .Include(x => x.OpenHints)
                                        .Where(x => x.Difficulty == levelDifficulty)
                                        .FirstOrDefault();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}