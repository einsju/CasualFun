namespace CasualFun.AtCirclesEdge.Player
{
    public interface IPlayerDataHandler
    {
        void Save(PlayerData data);
        PlayerData Load();
    }
}
