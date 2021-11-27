using CasualFun.Audio;
using CasualFun.Game;
using CasualFun.Player;
using CasualFun.Pooling;
using CasualFun.State;
using UnityEngine;

namespace CasualFun.Games.AtCirclesEdge
{
    public class GameManager : GameManagerBase
    {
        [SerializeField] AudioPlayer audioPlayer;
        [SerializeField] Spawner spawner;
        [SerializeField] int collectableEffectPoolIndex;
        [SerializeField] int explosionEffectPoolIndex = 1;
        
        public override void Awake()
        {
            base.Awake();
            GameStateEventHandler.PlayerPickedUpCollectable += PlayerPickedUpCollectable;
            GameStateEventHandler.PlayerPickedUpCoin += PlayerPickedUpCoin;
            GameStateEventHandler.PlayerWasHitByEnemy += PlayerWasHitByEnemy;
            PlayerData.NewHighScoreAchieved += NewHighScoreAchieved;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            GameStateEventHandler.PlayerPickedUpCollectable -= PlayerPickedUpCollectable;
            GameStateEventHandler.PlayerPickedUpCoin -= PlayerPickedUpCoin;
            GameStateEventHandler.PlayerWasHitByEnemy -= PlayerWasHitByEnemy;
            PlayerData.NewHighScoreAchieved -= NewHighScoreAchieved;
        }

        void PlayerWasHitByEnemy(Transform playerTransform)
        {
            SpawnEffect(explosionEffectPoolIndex, playerTransform.position, playerTransform.rotation);
            audioPlayer.OnGameOver();
            GameStateHandler.EndGame();
        }

        void PlayerPickedUpCollectable(Vector3 position)
        {
            scoreManager.AddScore(1);
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
            Debug.Log("Player got new high score. Yay!!!");
        }
    }
}
