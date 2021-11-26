using CasualFun.Storage;
using TMPro;
using UnityEngine;

namespace CasualFun.Managers
{
    public class PlayerDataManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI playerName;
        [SerializeField] TextMeshProUGUI highScoreText;
        [SerializeField] TextMeshProUGUI coinsText;

        PlayerData _playerData;
        PlayerDataService _service;
        IPlayerDataHandler _handler;
        int _highScoreKey;

        void Awake()
        {
            _handler = GetComponent<IPlayerDataHandler>();
            _service = new PlayerDataService(_handler);
            _playerData = _service.GetPlayerData() ?? new PlayerData();
            _highScoreKey = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
            ShowPlayerData();
            PlayerData.PlayerDataUpdated += PlayerDataUpdated;
        }

        void OnDestroy() => PlayerData.PlayerDataUpdated -= PlayerDataUpdated;

        void PlayerDataUpdated(PlayerData playerData)
        {
            _playerData = playerData;
            ShowPlayerData();
        }

        void ShowPlayerData()
        {
            playerName.text = _playerData.Name;
            // ReSharper disable once StringLiteralTypo
            highScoreText.text = $"Highscore: {GetHighScore().WithThousandSeparator()}";
            coinsText.text = $"{_playerData.Coins.WithThousandSeparator()}";
        }

        int GetHighScore() => _highScoreKey > 0
            ? _playerData.GetHighScore(_highScoreKey) : _playerData.TotalHighScore;
    }
}
