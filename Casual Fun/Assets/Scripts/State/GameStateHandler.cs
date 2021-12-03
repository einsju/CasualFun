using UnityEngine;

namespace CasualFun.AtCirclesEdge.State
{
    public class GameStateHandler : MonoBehaviour
    {
        public void StartGame() => GameStateEventHandler.OnGameStarted();
        public static void EndGame() => GameStateEventHandler.OnGameOver();
    }
}
