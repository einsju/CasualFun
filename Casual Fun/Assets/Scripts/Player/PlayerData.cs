using System;
using System.Collections.Generic;
using System.Linq;

namespace CasualFun.Player
{
    [Serializable]
    public class PlayerData
    {
        public const string DefaultPlayerName = "Guest";
        
        public static event Action<PlayerData> PlayerDataUpdated;
        public static event Action<int> NewHighScoreAchieved;
        
        public string Name { get; private set; }
        public int Coins { get; private set; }
        public Dictionary<int, int> GamesHighScores { get; private set; }

        public int TotalHighScore => GamesHighScores.Sum(gh => gh.Value);

        public PlayerData(string name = DefaultPlayerName, int coins = 1000)
        {
            Name = name;
            Coins = coins;
            GamesHighScores = new Dictionary<int, int>();
        }

        public void SetName(string name)
        {
            if (name == Name) return;
            if (string.IsNullOrEmpty(name)) name = DefaultPlayerName;
            Name = name;
            NotifyPlayerDataHasUpdated();
        }

        public void AddCoins(int coins)
        {
            if (coins < 0) return;
            Coins += coins;
            NotifyPlayerDataHasUpdated();
        }

        public int GetHighScore(int key)
            => GamesHighScores.ContainsKey(key) ? GamesHighScores[key] : 0;

        public void SetHighScore(int key, int score)
        {
            if (!ShouldSaveHighScore(key, score)) return;
            GamesHighScores[key] = score;
            NewHighScoreAchieved?.Invoke(score);
            NotifyPlayerDataHasUpdated();
        }
        
        bool ShouldSaveHighScore(int key, int score)
            => score > 0 && (!GamesHighScores.ContainsKey(key) || score > GamesHighScores[key]);
        
        void NotifyPlayerDataHasUpdated() => PlayerDataUpdated?.Invoke(this);
    }
}
