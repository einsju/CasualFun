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
        [SerializeField] GameAudioPlayer audioPlayer;
        [SerializeField] Spawner spawner;
        
        public bool GameIsRunning { get; private set; }

        void Awake() => Instance = this;

        void Start() => levelManager.PrepareLevel();

        public void StartGame()
        {
            GameIsRunning = true;
            SceneLoader.UnloadScene("_Menu");
            GameStateEventHandler.OnGameStarted();
        }
        
        IEnumerator GameOver()
        {
            GameIsRunning = false;
            audioPlayer.PlayGameOverSound();
            yield return new WaitForSeconds(1.5f);
            GameStateEventHandler.OnGameOver();
            yield return new WaitForSeconds(1f);
            levelManager.PrepareLevel();
            SceneLoader.LoadScene("_Menu");
        }

        public void PlayerWasHitByEnemy(Transform playerTransform)
        {
            spawner.Spawn((int)EffectPool.Explosion, playerTransform.position, playerTransform.rotation);
            StartCoroutine(GameOver());
        }
        
        public void PlayerPickedUpCoin(Vector3 position)
        {
            audioPlayer.PlayItemCollectedSound();
            spawner.Spawn((int)EffectPool.Collect, position, Quaternion.identity);
            PlayerDataInstance.Instance.PlayerData.AddCoins(1);
        }

        public void PlayerPickedUpScorePoint(Vector3 position)
        {
            audioPlayer.PlayItemCollectedSound();
            spawner.Spawn((int)EffectPool.Collect, position, Quaternion.identity);
            scoreManager.AddScore(1);
            
            if (levelManager.HasFinishedAllLevels)
            {
                GameIsRunning = false;
                GameStateEventHandler.OnLevelCompleted();
                Debug.Log("You have rounded all levels. Congrats to you for that!!!");
                return;
            }

            if (!levelManager.IsOnLastWave)
            {
                levelManager.OnWaveCompleted();
                return;
            }
            
            CompleteCurrentLevelAndPrepareTheNext();
        }

        void CompleteCurrentLevelAndPrepareTheNext()
        {
            GameIsRunning = false;
            PlayerDataInstance.Instance.PlayerData.IncreaseLevel();
            GameStateEventHandler.OnLevelCompleted();
            levelManager.PrepareLevel();
        }
    }
}
