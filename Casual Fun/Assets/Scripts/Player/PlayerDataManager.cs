using TMPro;
using UnityEngine;

namespace CasualFun.Player
{
    public class PlayerDataManager : MonoBehaviour
    {
        public static PlayerData PlayerData { get; private set; }
        public static int HighScoreKey { get; private set; }
        
        [SerializeField] TextMeshProUGUI playerName;
        [SerializeField] TextMeshProUGUI highScoreText;
        [SerializeField] TextMeshProUGUI coinsText;

        PlayerDataService _service;
        IPlayerDataHandler _handler;

        void Awake()
        {
            _handler = GetComponent<IPlayerDataHandler>();
            _service = new PlayerDataService(_handler);
            PlayerData = _service.GetPlayerData() ?? new PlayerData();
            HighScoreKey = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
            
            ShowPlayerData();
        }

        void OnEnable() => PlayerData.PlayerDataUpdated += PlayerDataUpdated;

        void OnDisable() => PlayerData.PlayerDataUpdated -= PlayerDataUpdated;

        void PlayerDataUpdated(PlayerData playerData)
        {
            PlayerData = playerData;
            ShowPlayerData();
        }

        void ShowPlayerData()
        {
            playerName.text = PlayerData.Name;
            // ReSharper disable once StringLiteralTypo
            highScoreText.text = $"Highscore: {GetHighScore().WithThousandSeparator()}";
            coinsText.text = $"{PlayerData.Coins.WithThousandSeparator()}";
        }

        static int GetHighScore() => HighScoreKey > 0
            ? PlayerData.GetHighScore(HighScoreKey) : PlayerData.TotalHighScore;
    }
}
