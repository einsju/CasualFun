using UnityEngine;

namespace CasualFun.AtCirclesEdge.State
{
    public class GameStateBehaviour : MonoBehaviour
    {
        [SerializeField] bool disableAtStartup = true;
        
        public virtual void Awake()
        {
            GameStateEventHandler.GameStarted += OnGameStarted;
            GameStateEventHandler.GameOver += OnGameOver;
            GameStateEventHandler.LevelCompleted += OnGameOver;
            enabled = !disableAtStartup;
        }

        void OnDestroy()
        {
            GameStateEventHandler.GameStarted -= OnGameStarted;
            GameStateEventHandler.GameOver -= OnGameOver;
            GameStateEventHandler.LevelCompleted -= OnGameOver;
        }

        protected virtual void OnGameStarted() => enabled = true;
        protected virtual void OnGameOver() => enabled = false;
    }
}
