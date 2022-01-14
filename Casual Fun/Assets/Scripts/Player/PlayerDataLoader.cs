using System;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Player
{
    public class PlayerDataLoader : MonoBehaviour
    {
        public static event Action<PlayerData> PlayerDataLoaded;

        PlayerDataService _service;
        IPlayerDataHandler _handler;

        void Awake()
        {
            _handler = GetComponent<IPlayerDataHandler>();
            _service = new PlayerDataService(_handler);
        }

        void Start() => PlayerDataLoaded?.Invoke(_service.GetPlayerData() ?? new PlayerData());
    }
}
