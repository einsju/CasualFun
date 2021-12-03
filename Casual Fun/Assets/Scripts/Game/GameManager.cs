using CasualFun.AtCirclesEdge.Audio;
using CasualFun.AtCirclesEdge.Player;
using CasualFun.AtCirclesEdge.Pooling;
using CasualFun.AtCirclesEdge.State;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        [SerializeField] protected ScoreManager scoreManager;
        [SerializeField] AudioPlayer audioPlayer;
        [SerializeField] Spawner spawner;
        [SerializeField] int collectableEffectPoolIndex;
        [SerializeField] int explosionEffectPoolIndex = 1;
        
        void Awake()
        {
            Instance = this;
            GameStateEventHandler.GameStarted += GameStarted;
            GameStateEventHandler.GameOver += GameOver;
            PlayerData.NewHighScoreAchieved += NewHighScoreAchieved;
        }

        void OnDestroy()
        {
            GameStateEventHandler.GameStarted -= GameStarted;
            GameStateEventHandler.GameOver -= GameOver;
            PlayerData.NewHighScoreAchieved -= NewHighScoreAchieved;
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

        public void PlayerWasHitByEnemy(Transform playerTransform)
        {
            SpawnEffect(explosionEffectPoolIndex, playerTransform.position, playerTransform.rotation);
            audioPlayer.OnGameOver();
            GameStateHandler.EndGame();
        }

        public void PlayerPickedUpCollectable(Vector3 position)
        {
            scoreManager.AddScore(1);
            SpawnEffect(collectableEffectPoolIndex, position, Quaternion.identity);
            audioPlayer.OnItemCollected();
        }
        
        public void PlayerPickedUpCoin(Vector3 position)
        {
            PlayerDataManager.PlayerData.AddCoins(1);
            SpawnEffect(collectableEffectPoolIndex, position, Quaternion.identity);
            audioPlayer.OnItemCollected();
        }
        
        void SpawnEffect(int poolIndex, Vector3 position, Quaternion rotation)
            => spawner.Spawn(poolIndex, position, rotation);

        static void NewHighScoreAchieved(int highScore)
        {
            // TODO
            // Notify player visually about the new high score
            // Debug.Log("Player got new high score. Yay!!!");
        }
    }
}
