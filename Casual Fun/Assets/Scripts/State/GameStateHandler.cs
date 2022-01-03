using UnityEngine;

namespace CasualFun.AtCirclesEdge.State
{
    public class GameStateHandler : MonoBehaviour
    {
        public static bool GameIsRunning { get; private set; }

        public void StartGame()
        {
            GameIsRunning = true;
            GameStateEventHandler.OnGameStarted();
        }

        public static void EndGame()
        {
            GameIsRunning = false;
            GameStateEventHandler.OnGameOver();
        }
    }
}
