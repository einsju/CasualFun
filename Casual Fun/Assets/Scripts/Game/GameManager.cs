using System.Collections;
using CasualFun.AtCirclesEdge.Audio;
using CasualFun.AtCirclesEdge.Game.Levels;
using CasualFun.AtCirclesEdge.Player;
using CasualFun.AtCirclesEdge.Pooling;
using CasualFun.AtCirclesEdge.State;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] AudioPlayer audioPlayer;
        [SerializeField] Spawner spawner;
        [SerializeField] int collectableEffectPoolIndex;
        [SerializeField] int explosionEffectPoolIndex = 1;

        LevelManager _levelManager;
        ScoreManager _scoreManager;
        
        void Awake()
        {
            _levelManager = GetComponent<LevelManager>();
            _scoreManager = GetComponent<ScoreManager>();
        }

        void OnEnable()
        {
            GameStateEventHandler.GameStarted += GameStarted;
            PlayerData.NewHighScoreAchieved += NewHighScoreAchieved;
            EventManager.PlayerPickedUpScorePoint += PlayerPickedUpScorePoint;
            EventManager.PlayerPickedUpCoin += PlayerPickedUpCoin;
            EventManager.PlayerWasHitByEnemy += PlayerWasHitByEnemy;
        }

        void Start() => _levelManager.InitializeLevel();

        void OnDisable()
        {
            GameStateEventHandler.GameStarted -= GameStarted;
            PlayerData.NewHighScoreAchieved -= NewHighScoreAchieved;
            EventManager.PlayerPickedUpScorePoint -= PlayerPickedUpScorePoint;
            EventManager.PlayerPickedUpCoin -= PlayerPickedUpCoin;
            EventManager.PlayerWasHitByEnemy -= PlayerWasHitByEnemy;
        }
        
        void GameStarted()
        {
            ResetTimeScale();
            _scoreManager.ResetScore();
        }

        IEnumerator GameOver()
        {
            ResetTimeScale();
            PlayerDataManager.PlayerData.SetHighScore(_scoreManager.Score);
            PlayerDataService.OnPlayerDataIsReadyToBeSaved(PlayerDataManager.PlayerData);
            yield return new WaitForSeconds(1.5f);
            GameStateHandler.EndGame();
            yield return new WaitForSeconds(1f);
            _levelManager.InitializeLevel();
        }

        static void ResetTimeScale() => Time.timeScale = 1;

        void PlayerWasHitByEnemy(Transform playerTransform)
        {
            SpawnEffect(explosionEffectPoolIndex, playerTransform.position, playerTransform.rotation);
            audioPlayer.OnGameOver();
            StartCoroutine(GameOver());
        }

        void PlayerPickedUpScorePoint(Vector3 position)
        {
            _scoreManager.AddScore(1);
            SpawnEffect(collectableEffectPoolIndex, position, Quaternion.identity);
            audioPlayer.OnItemCollected();

            if (!_levelManager.IsOnLastWave)
            {
                _levelManager.SpawnNextWave();
                return;
            }
            
            PlayerDataManager.PlayerData.IncreaseLevel();
            PlayerDataService.OnPlayerDataIsReadyToBeSaved(PlayerDataManager.PlayerData);
            _levelManager.InitializeLevel();
            
            // TODO: Reset player and show popup for completed level 
        }
        
        void PlayerPickedUpCoin(Vector3 position)
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
