using System.Collections;
using CasualFun.AtCirclesEdge.Audio;
using CasualFun.AtCirclesEdge.Game.Levels;
using CasualFun.AtCirclesEdge.Pooling;
using CasualFun.AtCirclesEdge.State;
using CasualFun.AtCirclesEdge.Utilities;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        [SerializeField] LevelManager levelManager;
        [SerializeField] ScoreManager scoreManager;
        [SerializeField] AudioPlayer audioPlayer;
        [SerializeField] MusicPlayer musicPlayer;
        [SerializeField] Spawner spawner;
        
        public bool GameIsRunning { get; private set; }

        void Awake() => Instance = this;

        void Start() => levelManager.PrepareLevel();

        public void StartGame()
        {
            GameIsRunning = true;
            GameStateEventHandler.OnGameStarted();
            musicPlayer.PlayMusic();
        }
        
        IEnumerator GameOver()
        {
            // GameIsRunning = false;
            // audioPlayer.OnGameOver();
            // yield return new WaitForSeconds(1.5f);
            // GameStateEventHandler.OnGameOver();
            // yield return new WaitForSeconds(1f);
            // levelManager.PrepareLevel();
            yield break;
        }

        public void PlayerWasHitByEnemy(Transform playerTransform)
        {
            musicPlayer.StopMusic();
            spawner.Spawn((int)EffectPool.Explosion, playerTransform.position, playerTransform.rotation);
            StartCoroutine(GameOver());
        }
        
        public void PlayerPickedUpCoin(Vector3 position)
        {
            ShowCollectionEffects(position);
            PlayerDataInstance.PlayerData.AddCoins(1);
        }

        public void PlayerPickedUpScorePoint(Vector3 position)
        {
            ShowCollectionEffects(position);
            scoreManager.AddScore(1);
            
            if (levelManager.HasFinishedAllLevels)
            {
                GameIsRunning = false;
                GameStateEventHandler.OnLevelCompleted();
                return;
            }

            if (!levelManager.IsOnLastWave)
            {
                levelManager.SpawnNextWave();
                return;
            }
            
            CompleteCurrentLevelAndPrepareTheNext();
        }

        void CompleteCurrentLevelAndPrepareTheNext()
        {
            GameIsRunning = false;
            GameStateEventHandler.OnLevelCompleted();
            PlayerDataInstance.PlayerData.IncreaseLevel();
            levelManager.PrepareLevel();
        }

        void ShowCollectionEffects(Vector3 position)
        {
            audioPlayer.OnItemCollected();
            spawner.Spawn((int)EffectPool.Collect, position, Quaternion.identity);
        }
    }
}
