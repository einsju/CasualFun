using System.Threading.Tasks;
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
            SceneLoader.UnloadScene(SceneNames.Menu);
            GameStateEventHandler.OnGameStarted();
        }
        
        async Task GameOver()
        {
            GameIsRunning = false;
            audioPlayer.PlayGameOverSound();
            PlayerDataInstance.Instance.PlayerData.SetHighScore(scoreManager.Score);
            await Task.Delay(1000);
            GameStateEventHandler.OnGameOver();
            await Task.Delay(500);
            levelManager.PrepareLevel();
            SceneLoader.LoadScene(SceneNames.Menu);
        }

        public async Task PlayerWasHitByEnemy(Transform playerTransform)
        {
            spawner.Spawn((int)EffectPool.Explosion, playerTransform.position, playerTransform.rotation);
            await GameOver();
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
