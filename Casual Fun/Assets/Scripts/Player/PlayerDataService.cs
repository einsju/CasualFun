using System;
using UnityEngine;

namespace CasualFun.Player
{
    public class PlayerDataService
    {
        static event Action<PlayerData> PlayerDataIsReadyToBeSaved;

        public static void OnPlayerDataIsReadyToBeSaved(PlayerData playerData)
            => PlayerDataIsReadyToBeSaved?.Invoke(playerData);
        
        readonly IPlayerDataHandler _handler;

        public PlayerDataService(IPlayerDataHandler handler)
        {
            _handler = handler;
            PlayerDataIsReadyToBeSaved += SavePlayerData;
        }

        ~PlayerDataService() => PlayerDataIsReadyToBeSaved -= SavePlayerData;

        public PlayerData GetPlayerData() => _handler.Load();

        void SavePlayerData(PlayerData data) => _handler.Save(data);
    }
}
