using CasualFun.Handlers;
using CasualFun.Managers;
using UnityEngine;

namespace CasualFun.Games.AtCirclesEdge
{
    public class GameManager : GameManagerBase
    {
        [SerializeField] AudioPlayer audioPlayer;
        [SerializeField] Spawner spawner;
        [SerializeField] int collectableEffectPoolIndex;
        [SerializeField] int explosionEffectPoolIndex;
        
        public override void Awake()
        {
            base.Awake();
            GameStateEventHandler.PlayerPickedUpCollectable += PlayerPickedUpCollectable;
            GameStateEventHandler.PlayerWasHitByEnemy += PlayerWasHitByEnemy;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            GameStateEventHandler.PlayerPickedUpCollectable -= PlayerPickedUpCollectable;
            GameStateEventHandler.PlayerWasHitByEnemy -= PlayerWasHitByEnemy;
        }

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
            scoreManager.AddScore(1);
            SpawnPickUpEffect(position);
            audioPlayer.OnItemCollected();
        }

        void SpawnPickUpEffect(Vector3 position)
            => spawner.Spawn(collectableEffectPoolIndex, position, Quaternion.identity);
    }
}
