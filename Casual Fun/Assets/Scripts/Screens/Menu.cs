using CasualFun.AtCirclesEdge.Game;
using CasualFun.AtCirclesEdge.Utilities;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Screens
{
    public class Menu : MonoBehaviour
    {
        public void OnOptions() => SceneLoader.LoadScene(SceneNames.Options);

        public void OnStore() => SceneLoader.LoadScene(SceneNames.Store);

        public void OnLevels() => SceneLoader.LoadScene(SceneNames.Levels);

        public void OnLeaderboard() => SceneLoader.LoadScene(SceneNames.Leaderboard);

        public void OnStartGame() => GameManager.Instance.StartGame();
    }
}
