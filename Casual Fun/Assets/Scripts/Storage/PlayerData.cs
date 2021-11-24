using System;
using System.Collections.Generic;
using System.Linq;

namespace CasualFun.Storage
{
    [Serializable]
    public class PlayerData
    {
        public string Name { get; private set; }
        public int Coins { get; private set; }
        public Dictionary<int, int> GamesHighScores { get; private set; }

        public int HighScore => GamesHighScores.Sum(gh => gh.Value);

        public PlayerData(string name, int coins, Dictionary<int, int> highScores)
        {
            Name = name;
            Coins = coins;
            GamesHighScores = highScores;
        }

        public void AddCoins(int coins) => Coins += coins;
        
        public void SetHighScore(int gameIndex, int score)
        {
            if (!ShouldSaveHighScore(gameIndex, score)) return;
            GamesHighScores[gameIndex] = score;
        }

        bool ShouldSaveHighScore(int gameIndex, int score)
            => GamesHighScores.ContainsKey(gameIndex) && score > GamesHighScores[gameIndex];
    }
}
