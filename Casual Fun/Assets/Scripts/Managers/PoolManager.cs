using System.Collections.Generic;
using CasualFun.Handlers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CasualFun.Managers
{
    public class PoolManager
    {
        readonly GameObject _poolObject;
        readonly Queue<GameObject> _poolObjects;

        public PoolManager(GameObject poolObject, Transform parent, int size = 10)
        {
            _poolObject = poolObject;
            _poolObjects = new Queue<GameObject>(size);
            
            CreatePool(parent, size);
            GameStateEventHandler.GameOver += ResetPool;
        }
        
        ~PoolManager() => GameStateEventHandler.GameOver -= ResetPool;

        void CreatePool(Transform parent, int size)
        {
            for (var i = 0; i < size; i++)
                _poolObjects.Enqueue(Object.Instantiate(_poolObject, parent, true));
        }

        public GameObject TakeFromPool(Vector3 position, Quaternion rotation) => Take(position, rotation);
        
        GameObject Take(Vector3 position, Quaternion rotation)
        {
            var objectFromStack = _poolObjects.Dequeue();
            objectFromStack.transform.position = position;
            objectFromStack.transform.rotation = rotation;
            objectFromStack.SetActive(true);
            _poolObjects.Enqueue(objectFromStack);
           
            return objectFromStack;
        }

        void ResetPool()
        {
            foreach (var gameObject in _poolObjects)
                gameObject.SetActive(false);
        }
    }
}
