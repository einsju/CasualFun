using System.Linq;
using CasualFun.Managers;
using UnityEngine;

namespace CasualFun
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] Pool[] pools;
        
        PoolManager _poolManager;

        void Awake() => _poolManager = new PoolManager(pools.ToList(), transform);

        public void Spawn(int poolIndex, Vector3 position, Quaternion rotation)
            => _poolManager.TakeFromPool(pools[poolIndex], position, rotation);
    }
}
