namespace CasualFun.Storage
{
    public class PlayerDataService
    {
        readonly IPlayerDataHandler _handler;

        public PlayerDataService(IPlayerDataHandler handler) => _handler = handler;

        public PlayerData GetPlayerData() => _handler.Load();

        public void SavePlayerData(PlayerData data) => _handler.Save(data);
    }
}
