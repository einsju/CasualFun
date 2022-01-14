using UnityEngine;

namespace CasualFun.AtCirclesEdge.State
{
    public class GameStateElement : MonoBehaviour
    {
        [SerializeField] bool hiddenWhenGameIsRunning = true;
        
        void Awake()
        {
            GameStateEventHandler.GameStarted += GameStarted;
            GameStateEventHandler.GameOver += GameOver;
            GameStateEventHandler.LevelCompleted += LevelCompleted;
        }

        void OnDestroy()
        {
            GameStateEventHandler.GameStarted -= GameStarted;
            GameStateEventHandler.GameOver -= GameOver;
            GameStateEventHandler.LevelCompleted -= LevelCompleted;
        }

        void GameStarted() => gameObject.SetActive(!hiddenWhenGameIsRunning);
        
        void GameOver() => gameObject.SetActive(hiddenWhenGameIsRunning);
        
        void LevelCompleted() => gameObject.SetActive(hiddenWhenGameIsRunning);
    }
}
