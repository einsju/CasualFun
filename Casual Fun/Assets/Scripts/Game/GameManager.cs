using System;
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
            GameStateEventHandler.GameStarted += GameStarted;
            GameStateEventHandler.GameOver += GameOver;
            PlayerData.NewHighScoreAchieved += NewHighScoreAchieved;
            EventManager.PlayerPickedUpCollectable += PlayerPickedUpCollectable;
            EventManager.PlayerPickedUpCoin += PlayerPickedUpCoin;
            EventManager.PlayerWasHitByEnemy += PlayerWasHitByEnemy;
        }

        void Start() => _levelManager.PrepareLevel();

        void OnDestroy()
        {
            GameStateEventHandler.GameStarted -= GameStarted;
            GameStateEventHandler.GameOver -= GameOver;
            PlayerData.NewHighScoreAchieved -= NewHighScoreAchieved;
            EventManager.PlayerPickedUpCollectable -= PlayerPickedUpCollectable;
            EventManager.PlayerPickedUpCoin -= PlayerPickedUpCoin;
            EventManager.PlayerWasHitByEnemy -= PlayerWasHitByEnemy;
        }
        
        void GameStarted()
        {
            ResetTimeScale();
            _scoreManager.ResetScore();
        }

        void GameOver()
        {
            ResetTimeScale();
            PlayerDataManager.PlayerData.SetHighScore(_scoreManager.Score);
            PlayerDataService.OnPlayerDataIsReadyToBeSaved(PlayerDataManager.PlayerData);
            _levelManager.PrepareLevel();
        }

        static void ResetTimeScale() => Time.timeScale = 1;

        void PlayerWasHitByEnemy(Transform playerTransform)
        {
            SpawnEffect(explosionEffectPoolIndex, playerTransform.position, playerTransform.rotation);
            audioPlayer.OnGameOver();
            GameStateHandler.EndGame();
        }

        void PlayerPickedUpCollectable(Vector3 position)
        {
            _scoreManager.AddScore(1);
            SpawnEffect(collectableEffectPoolIndex, position, Quaternion.identity);
            audioPlayer.OnItemCollected();
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
