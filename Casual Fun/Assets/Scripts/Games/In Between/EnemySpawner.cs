using CasualFun.Pooling;
using CasualFun.State;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CasualFun.Games.InBetween
{
    public class EnemySpawner : GameStateBehaviour
    {
        // [SerializeField] float spawnRate = 0.3f;
        // [SerializeField] Pool enemy;
        // [SerializeField] Player player;
        //
        // float _timer;
        // PoolManager _poolManager;
        //
        // public override void Awake()
        // {
        //     _poolManager = new PoolManager(enemy, transform);
        //     base.Awake();
        // }
        //
        // void Update()
        // {
        //     _timer += Time.deltaTime;
        //
        //     if (!CanSpawn) return;
        //     Spawn();
        //     _timer = 0f;
        // }
        //
        // bool CanSpawn => _timer >= spawnRate;
        //
        // void Spawn() => LaunchEnemy(_poolManager.TakeFromPool(enemy, Vector2.zero, player.transform.rotation));
        //
        // void LaunchEnemy(GameObject enemyFromPool) => enemyFromPool.transform.eulerAngles += LaunchDirection;
        //
        // Vector3 LaunchDirection => player.Speed < 0 ? Left : Right;
        // static Vector3 Left => new Vector3(0, 0, Random.Range(0, -90));
        // static Vector3 Right => new Vector3(0, 0, Random.Range(0, 90));
    }
}
