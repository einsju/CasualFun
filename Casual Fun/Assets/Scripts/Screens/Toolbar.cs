using CasualFun.AtCirclesEdge.Utilities;
using TMPro;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Screens
{
    public class Toolbar : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI playerName;
        [SerializeField] TextMeshProUGUI coins;

        void Awake() => PlayerDataInstance.PlayerDataInstanceUpdated += ShowPlayerData;

        void Start() => ShowPlayerData();

        void OnDestroy() => PlayerDataInstance.PlayerDataInstanceUpdated -= ShowPlayerData;

        void ShowPlayerData()
        {
            if (PlayerDataInstance.Instance.PlayerData is null) return;
            playerName.text = PlayerDataInstance.Instance.PlayerData.Name;
            coins.text = $"{PlayerDataInstance.Instance.PlayerData.Coins.WithThousandSeparator()}";
        }
    }
}
