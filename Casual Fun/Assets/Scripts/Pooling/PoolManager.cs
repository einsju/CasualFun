using System.Collections.Generic;
using System.Linq;
using CasualFun.AtCirclesEdge.State;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CasualFun.AtCirclesEdge.Pooling
{
    public class PoolManager
    {
        readonly Dictionary<Pool, Queue<GameObject>> _pools = new Dictionary<Pool, Queue<GameObject>>();

        PoolManager()
        {
            GameStateEventHandler.LevelCompleted += ResetPools;
            GameStateEventHandler.GameOver += ResetPools;
        }

        public PoolManager(Pool toPool, Transform parent) : this()
            => InitializePool(new List<Pool> { toPool }, parent);

        public PoolManager(List<Pool> toPool, Transform parent) : this()
            => InitializePool(toPool, parent);

        void InitializePool(List<Pool> toPool, Transform parent)
        {
            toPool.ForEach(itp => _pools.Add(itp, new Queue<GameObject>(itp.size)));
            CreatePool(parent);
        }
        
        ~PoolManager()
        {
            GameStateEventHandler.GameOver -= ResetPools;
            GameStateEventHandler.LevelCompleted -= ResetPools;
        }

        void CreatePool(Transform parent)
        {
            foreach (var pool in _pools)
                for (var i = 0; i < pool.Key.size; i++)
                    pool.Value.Enqueue(Object.Instantiate(pool.Key.gameObject, parent, true));
        }

        public GameObject TakeFromPool(Pool pool, Vector3 position, Quaternion rotation)
            => Take(pool, position, rotation);
        
        public GameObject TakeFromPoolUsingLocalPosition(Pool pool, Vector3 position, Quaternion rotation)
            => Take(pool, position, rotation, true);
        
        GameObject Take(Pool pool, Vector3 position, Quaternion rotation, bool usingLocalPosition = false)
        {
            var correctPool = FindPool(pool);
            var itemFromPool = correctPool.Value.Dequeue();

            if (itemFromPool is null) return null;

            if (!usingLocalPosition)
                itemFromPool.transform.position = position;
            else
                itemFromPool.transform.localPosition = position;
            
            itemFromPool.transform.rotation = rotation;
            ActivatePoolMember(pool.shouldDeactivateMembersBeforeUse, itemFromPool);
            correctPool.Value.Enqueue(itemFromPool);

            return itemFromPool.gameObject;
        }

        static void ActivatePoolMember(bool shouldDeactivateFirst, GameObject poolMember)
        {
            if (shouldDeactivateFirst) poolMember.SetActive(false);
            poolMember.SetActive(true);
        }
        
        KeyValuePair<Pool, Queue<GameObject>> FindPool(Pool pool)
            => _pools.First(pi => pi.Key == pool);

        void ResetPools()
        {
            foreach (var gameObject in _pools.SelectMany(pool => pool.Value))
                if (gameObject != null) gameObject.SetActive(false);
        }
    }
}
