using MyHangman.Data;
using MyHangman.DTO;
using MyHangman.Models;
using System.Collections.Generic;
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

        public Player GetPlayerByID(string userID)
        {
            return context.Users.Include(x => x.CompleteLevels).Where(x => x.Id == userID).FirstOrDefault();
        }

        public List<Player> GetAllPlayers()
        {
            return context.Users.Include(x => x.CompleteLevels).OrderByDescending(x => x.GameScore).ToList();
        }

        public void UpdatePlayer(LetterProcessingDTO dto)
        {
            Player player = GetPlayerByID(dto.PlayerID);

            player.GameScore = dto.GameScore;
            player.GoldenCoins = dto.GoldenCoins;

            Save();
        }

        public Level GetLevelByID(int levelID)
        {
            return context.Levels.Include(x => x.Hints)
                                 .Where(x => x.ID == levelID)
                                 .SingleOrDefault();
        }

        public List<Level> GetAllLevels()
        {
            return context.Levels.Include(x => x.Hints).ToList();
        }

        public OpenHint GetOpenHint(string playerID, int hintID)
        {
            return context.OpenHints.SingleOrDefault(x => x.PlayerID == playerID && x.HintID == hintID);
        }

        public void SaveOpenHint(OpenHint openHint)
        {
            context.OpenHints.Add(openHint);
            context.SaveChanges();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}