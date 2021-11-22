using CasualFun.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CasualFun.Games.AtCirclesEdge
{
    public class EnemySpawner : GameBehaviour
    {
        [SerializeField] float spawnRate = 0.3f;
        [SerializeField] Enemy enemy;
        [SerializeField] Player player;

        float _timer;
        PoolManager _poolManager;

        public override void Awake()
        {
            _poolManager = new PoolManager(enemy.gameObject, transform);
            base.Awake();
        }

        void Update()
        {
            _timer += Time.deltaTime;
            
            if (!CanSpawn) return;
            
            Spawn();
            _timer = 0f;
        }
        
        bool CanSpawn => _timer >= spawnRate;
        
        void Spawn() => LaunchEnemy(_poolManager.TakeFromPool(Vector2.zero, player.transform.rotation));

        void LaunchEnemy(GameObject enemyFromPool) => enemyFromPool.transform.eulerAngles += LaunchDirection;
        
        Vector3 LaunchDirection => player.Speed < 0 ? LeftLaunchDirection : RightLaunchDirection;
        static Vector3 LeftLaunchDirection => new Vector3(0, 0, Random.Range(0, -90));
        static Vector3 RightLaunchDirection => new Vector3(0, 0, Random.Range(0, 90));
    }
}
