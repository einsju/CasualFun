using TMPro;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Player
{
    public class PlayerDataManager : MonoBehaviour
    {
        public static PlayerData PlayerData { get; private set; }
        
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
            highScoreText.text = $"High score: {PlayerData.HighScore.WithThousandSeparator()}";
            coinsText.text = $"{PlayerData.Coins.WithThousandSeparator()}";
        }
    }
}
