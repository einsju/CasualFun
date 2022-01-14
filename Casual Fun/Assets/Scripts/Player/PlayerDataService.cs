namespace CasualFun.AtCirclesEdge.Player
{
    public class PlayerDataService
    {   
        readonly IPlayerDataHandler _handler;

        public PlayerDataService(IPlayerDataHandler handler) => _handler = handler;

        //~PlayerDataService() => SavePlayerData();

        public PlayerData GetPlayerData() => _handler.Load();
        
        void SavePlayerData() => _handler.Save(PlayerDataInstance.PlayerData);
    }
}
