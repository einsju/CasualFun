namespace CasualFun.Storage
{
    public interface IPlayerDataHandler
    {
        void Save(PlayerData data);
        PlayerData Load();
    }
}
