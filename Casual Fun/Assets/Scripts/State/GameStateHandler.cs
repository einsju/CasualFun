using UnityEngine;

namespace CasualFun.AtCirclesEdge.State
{
    public class GameStateHandler : MonoBehaviour
    {
        [SerializeField] GameObject pauseButton;
        [SerializeField] GameObject resumeButton;
        
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

        public void PauseGame()
        {
            GameIsRunning = false;
            pauseButton.SetActive(false);
            resumeButton.SetActive(true);
        }

        public void ResumeGame()
        {
            GameIsRunning = true;
            resumeButton.SetActive(false);
            pauseButton.SetActive(true);
        }
    }
}
