using CasualFun.State;
using UnityEngine;

namespace CasualFun.Game
{
    public abstract class GameManagerBase : MonoBehaviour
    {
        [SerializeField] protected ScoreManager scoreManager;
        
        public virtual void Awake()
        {
            GameStateEventHandler.GameStarted += GameStarted;
            GameStateEventHandler.GameOver += GameOver;
        }

        public virtual void OnDestroy()
        {
            GameStateEventHandler.GameStarted -= GameStarted;
            GameStateEventHandler.GameOver -= GameOver;
        }

        void GameStarted()
        {
            scoreManager.ResetScore();
            ResetTimeScale();
        }

        static void GameOver() => ResetTimeScale();
        
        static void ResetTimeScale() => Time.timeScale = 1;
    }
}
