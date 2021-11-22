using CasualFun.Handlers;
using UnityEngine;

namespace CasualFun.Games.AtCirclesEdge
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        
        [SerializeField] AudioPlayer audioPlayer;
        [SerializeField] GameObject explosionPrefab;
        [SerializeField] GameObject collectedPrefab;
        
        void Awake()
        {
            Instance = this;
            GameStateEventHandler.GameStarted += GameStarted;
            GameStateEventHandler.GameOver += GameOver;
        }

        void OnDestroy()
        {
            GameStateEventHandler.GameStarted -= GameStarted;
            GameStateEventHandler.GameOver -= GameOver;
        }

        static void GameStarted() => ResetTimeScale();
        static void GameOver() => ResetTimeScale();

        static void ResetTimeScale() => Time.timeScale = 1;

        public void PlayerWasHitByEnemy(Transform playerTransform)
        {
            Instantiate(explosionPrefab, playerTransform.position, playerTransform.rotation);
            audioPlayer.OnGameOver();
            GameStateHandler.EndGame();
        }

        public void PlayerPickedUpCollectable(Vector3 position)
        {
            Instantiate(collectedPrefab, position, Quaternion.identity);
            audioPlayer.OnItemCollected();
        }
    }
}
