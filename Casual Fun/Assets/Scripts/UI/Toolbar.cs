using CasualFun.AtCirclesEdge.Utilities;
using TMPro;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.UI
{
    public class Toolbar : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI playerName;
        [SerializeField] TextMeshProUGUI highScore;
        [SerializeField] TextMeshProUGUI coins;

        void Awake() => PlayerDataInstance.PlayerDataInstanceUpdated += ShowPlayerData;

        void OnDestroy() => PlayerDataInstance.PlayerDataInstanceUpdated -= ShowPlayerData;

        void ShowPlayerData()
        {
            playerName.text = PlayerDataInstance.PlayerData.Name;
            highScore.text = $"High score: {PlayerDataInstance.PlayerData.HighScore.WithThousandSeparator()}";
            coins.text = $"{PlayerDataInstance.PlayerData.Coins.WithThousandSeparator()}";
        }
    }
}
