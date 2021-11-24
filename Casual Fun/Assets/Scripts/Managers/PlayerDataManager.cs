using CasualFun.Storage;
using TMPro;
using UnityEngine;

namespace CasualFun.Managers
{
    public class PlayerDataManager : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI highScoreText;
        [SerializeField] TextMeshProUGUI coinsText;

        PlayerData _playerData;
        PlayerDataService _service;
        IPlayerDataHandler _handler;

        void Awake()
        {
            _handler = GetComponent<IPlayerDataHandler>();
            _service = new PlayerDataService(_handler);
            _playerData = _service.GetPlayerData();
            ShowPlayerData();
        }

        void ShowPlayerData()
        {
            // ReSharper disable once StringLiteralTypo
            highScoreText.text = $"Highscore: {(_playerData?.HighScore ?? 0).WithThousandSeparator()}";
            coinsText.text = $"{(_playerData?.Coins ?? 1000).WithThousandSeparator()}";
        }
    }
}
