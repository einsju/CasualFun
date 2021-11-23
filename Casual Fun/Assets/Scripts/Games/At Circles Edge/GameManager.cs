using CasualFun.Handlers;
using UnityEngine;

namespace CasualFun.Games.AtCirclesEdge
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] AudioPlayer audioPlayer;
        [SerializeField] GameObject explosionPrefab;
        [SerializeField] GameObject collectedPrefab;
        
        void Awake()
        {
            GameStateEventHandler.GameStarted += GameStarted;
            GameStateEventHandler.GameOver += GameOver;
            GameStateEventHandler.PlayerPickedUpCollectable += PlayerPickedUpCollectable;
            GameStateEventHandler.PlayerWasHitByEnemy += PlayerWasHitByEnemy;
        }

        void OnDestroy()
        {
            GameStateEventHandler.GameStarted -= GameStarted;
            GameStateEventHandler.GameOver -= GameOver;
            GameStateEventHandler.PlayerPickedUpCollectable -= PlayerPickedUpCollectable;
            GameStateEventHandler.PlayerWasHitByEnemy -= PlayerWasHitByEnemy;
        }

        static void GameStarted() => ResetTimeScale();
        static void GameOver() => ResetTimeScale();

        static void ResetTimeScale() => Time.timeScale = 1;

        void PlayerWasHitByEnemy(Transform playerTransform)
        {
            Instantiate(explosionPrefab, playerTransform.position, playerTransform.rotation);
            audioPlayer.OnGameOver();
            GameStateHandler.EndGame();
        }

        void PlayerPickedUpCollectable(Vector3 position)
        {
            Instantiate(collectedPrefab, position, Quaternion.identity);
            audioPlayer.OnItemCollected();
        }
    }
}
