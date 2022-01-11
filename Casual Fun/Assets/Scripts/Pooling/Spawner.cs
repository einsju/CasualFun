using System.Linq;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Pooling
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] Pool[] pools;
        
        PoolManager _poolManager;

        void Awake() => _poolManager = new PoolManager(pools.ToList(), transform);

        public void Spawn(int poolIndex, Vector3 position, Quaternion rotation)
            => _poolManager.TakeFromPool(pools[poolIndex], position, rotation);
        
        public GameObject SpawnWithLocalPosition(int poolIndex, Vector3 position, Quaternion rotation)
            => _poolManager.TakeFromPoolUsingLocalPosition(pools[poolIndex], position, rotation);
    }
}
