using CasualFun.AtCirclesEdge.Audio;
using CasualFun.AtCirclesEdge.Pooling;
using CasualFun.AtCirclesEdge.State;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CasualFun.AtCirclesEdge.Game
{
    public class EnemySpawner : GameStateBehaviour
    {
        [SerializeField] float spawnRate = 0.5f;
        [SerializeField] Pool enemy;
        [SerializeField] Player player;
        [SerializeField] AudioPlayer audioPlayer;

        float _timer;
        PoolManager _poolManager;

        public override void Awake()
        {
            _poolManager = new PoolManager(enemy, transform);
            base.Awake();
        }

        void Update()
        {
            if (!GameStateHandler.GameIsRunning) return;
            _timer += Time.deltaTime;

            if (!CanSpawn) return;
            Spawn();
            _timer = 0f;
        }
        
        bool CanSpawn => _timer >= spawnRate;
        
        void Spawn() => LaunchEnemy(_poolManager.TakeFromPool(enemy, Vector2.zero, player.transform.rotation));

        void LaunchEnemy(GameObject enemyFromPool)
        {
            audioPlayer.OnEnemySpawned();
            enemyFromPool.transform.eulerAngles += LaunchDirection;
        }

        Vector3 LaunchDirection => player.Speed < 0 ? Left : Right;
        static Vector3 Left => new Vector3(0, 0, Random.Range(0, -90));
        static Vector3 Right => new Vector3(0, 0, Random.Range(0, 90));
    }
}
