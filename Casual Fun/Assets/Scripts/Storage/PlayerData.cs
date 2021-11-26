using System;
using System.Collections.Generic;
using System.Linq;

namespace CasualFun.Storage
{
    [Serializable]
    public class PlayerData
    {
        public static event Action<PlayerData> PlayerDataUpdated;
        
        public string Name { get; private set; }
        public int Coins { get; private set; }
        public Dictionary<int, int> GamesHighScores { get; private set; }

        public int TotalHighScore => GamesHighScores.Sum(gh => gh.Value);

        public PlayerData(string name = "Guest", int coins = 1000)
        {
            Name = name;
            Coins = coins;
            GamesHighScores = new Dictionary<int, int>();
        }

        public void SetName(string name)
        {
            Name = name;
            NotifyPlayerDataHasUpdated();
        }

        public void AddCoins(int coins)
        {
            Coins += coins;
            NotifyPlayerDataHasUpdated();
        }

        public int GetHighScore(int key)
            => GamesHighScores.ContainsKey(key) ? GamesHighScores[key] : 0;

        public void SetHighScore(int key, int score)
        {
            if (!ShouldSaveHighScore(key, score)) return;
            GamesHighScores[key] = score;
            NotifyPlayerDataHasUpdated();
        }
        
        bool ShouldSaveHighScore(int gameIndex, int score)
            => GamesHighScores.ContainsKey(gameIndex) && score > GamesHighScores[gameIndex];

        void NotifyPlayerDataHasUpdated() => PlayerDataUpdated?.Invoke(this);
    }
}
