namespace CasualFun.Player
{
    public class PlayerDataService
    {
        readonly IPlayerDataHandler _handler;

        public PlayerDataService(IPlayerDataHandler handler)
        {
            _handler = handler;
            PlayerData.PlayerDataUpdated += SavePlayerData;
        }

        ~PlayerDataService() => PlayerData.PlayerDataUpdated -= SavePlayerData;

        public PlayerData GetPlayerData() => _handler.Load();

        void SavePlayerData(PlayerData data) => _handler.Save(data);
    }
}
