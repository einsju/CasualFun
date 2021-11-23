using CasualFun.Handlers;
using UnityEngine;

namespace CasualFun.Games.AtCirclesEdge
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] AudioPlayer audioPlayer;
        [SerializeField] Spawner spawner;
        [SerializeField] int collectableEffectPoolIndex;
        [SerializeField] int explosionEffectPoolIndex;
        
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
            SpawnExplosionEffect(playerTransform);
            audioPlayer.OnGameOver();
            GameStateHandler.EndGame();
        }

        void SpawnExplosionEffect(Transform playerTransform)
            => spawner.Spawn(explosionEffectPoolIndex, playerTransform.position, playerTransform.rotation);

        void PlayerPickedUpCollectable(Vector3 position)
        {
            SpawnPickUpEffect(position);
            audioPlayer.OnItemCollected();
        }

        void SpawnPickUpEffect(Vector3 position)
            => spawner.Spawn(collectableEffectPoolIndex, position, Quaternion.identity);
    }
}
