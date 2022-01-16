using CasualFun.AtCirclesEdge.State;

namespace CasualFun.AtCirclesEdge.Player
{
    public class PlayerDataService
    {   
        readonly IPlayerDataHandler _handler;

        public PlayerDataService(IPlayerDataHandler handler)
        {
            _handler = handler;
            GameStateEventHandler.LevelCompleted += SavePlayerData;
            GameStateEventHandler.GameOver += SavePlayerData;
        }

        ~PlayerDataService()
        {
            GameStateEventHandler.LevelCompleted -= SavePlayerData;
            GameStateEventHandler.GameOver -= SavePlayerData;
        }

        public PlayerData GetPlayerData() => _handler.Load();
        
        void SavePlayerData() => _handler.Save(PlayerDataInstance.Instance.PlayerData);
    }
}
