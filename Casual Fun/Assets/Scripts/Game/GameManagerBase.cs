using CasualFun.Player;
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
            ResetTimeScale();
            scoreManager.ResetScore();
        }

        void GameOver()
        {
            ResetTimeScale();
            PlayerDataManager.PlayerData.SetHighScore(PlayerDataManager.HighScoreKey, scoreManager.Score);
            PlayerDataService.OnPlayerDataIsReadyToBeSaved(PlayerDataManager.PlayerData);
        }

        static void ResetTimeScale() => Time.timeScale = 1;
    }
}
