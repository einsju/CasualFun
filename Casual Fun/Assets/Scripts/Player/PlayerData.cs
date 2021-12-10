using System;

namespace CasualFun.AtCirclesEdge.Player
{
    [Serializable]
    public class PlayerData
    {
        public const string DefaultPlayerName = "Guest";
        
        public static event Action<PlayerData> PlayerDataUpdated;
        public static event Action<int> NewHighScoreAchieved;
        
        public string Name { get; private set; }
        public int Coins { get; private set; }
        public int HighScore { get; private set; }

        public PlayerData(string name = DefaultPlayerName, int coins = 1000)
        {
            Name = name;
            Coins = coins;
            HighScore = 0;
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

        public void SetHighScore(int score)
        {
            if (score < HighScore) return;
            HighScore = score;
            NewHighScoreAchieved?.Invoke(score);
            NotifyPlayerDataHasUpdated();
        }
        
        void NotifyPlayerDataHasUpdated() => PlayerDataUpdated?.Invoke(this);
    }
}
