using UnityEngine;

namespace CasualFun.AtCirclesEdge.Screens
{
    public class Menu : MonoBehaviour
    {
        void Awake() => SceneLoader.LoadScene("_Toolbar");

        public void OnOptions() => SceneLoader.LoadScene("_Options");

        public void OnStore() => SceneLoader.LoadScene("_Store");

        public void OnLevels() => SceneLoader.LoadScene("_Levels");

        public void OnLeaderboard() => SceneLoader.LoadScene("_Leaderboard");
    }
}
