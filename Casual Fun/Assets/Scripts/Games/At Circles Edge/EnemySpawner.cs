using CasualFun.Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CasualFun.Games.AtCirclesEdge
{
    public class EnemySpawner : GameBehaviour
    {
        [SerializeField] float spawnRate = 0.3f;
        [SerializeField] GameObject enemy;

        float _timer;
        Vector3 _launchDirection;
        PoolManager _poolManager;

        public override void Awake()
        {
            _poolManager = new PoolManager(enemy, transform);
            base.Awake();
        }

        void OnEnable() => PlayerMovement.PlayerChangedDirection += SetLaunchDirection;
        void OnDisable() => PlayerMovement.PlayerChangedDirection -= SetLaunchDirection;
        
        void SetLaunchDirection(float speed)
            => _launchDirection = speed < 0 ? LeftLaunchDirection : RightLaunchDirection;

        static Vector3 LeftLaunchDirection => new Vector3(0, 0, Random.Range(0, -90));
        static Vector3 RightLaunchDirection => new Vector3(0, 0, Random.Range(0, 90));

        void Update()
        {
            _timer += Time.deltaTime;
            
            if (!CanSpawn) return;
            
            Spawn();
            _timer = 0f;
        }

        bool CanSpawn => _timer >= spawnRate;

        void Spawn()
        {
            var poolObject = _poolManager.TakeFromPool(Vector2.zero, transform.rotation);
            poolObject.transform.eulerAngles += _launchDirection;
        }
    }
}
