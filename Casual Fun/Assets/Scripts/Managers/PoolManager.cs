using System.Collections.Generic;
using System.Linq;
using CasualFun.Handlers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CasualFun.Managers
{
    public class PoolManager
    {
        readonly GameObject _poolObject;
        readonly Stack<GameObject> _availableObjects;
        
        IList<GameObject> _allObjects;

        public PoolManager(GameObject poolObject, Transform parent, int size = 20)
        {
            _poolObject = poolObject;
            _availableObjects = new Stack<GameObject>(size);
            
            CreatePool(parent, size);
            GameStateEventHandler.GameOver += ResetPool;
        }
        
        ~PoolManager() => GameStateEventHandler.GameOver -= ResetPool;

        void CreatePool(Transform parent, int size)
        {
            for (var i = 0; i < size; i++)
                _availableObjects.Push(Object.Instantiate(_poolObject, parent, true));
            
            _allObjects = _availableObjects.ToList();
        }

        public GameObject TakeFromPool(Vector3 position, Quaternion rotation)
            => Take(position, rotation);
        
        GameObject Take(Vector3 position, Quaternion rotation)
        {
            var objectFromStack = _availableObjects.Pop();
            objectFromStack.transform.position = position;
            objectFromStack.transform.rotation = rotation;
            objectFromStack.SetActive(true);
           
            return objectFromStack;
        }

        void ReturnToPool(GameObject objectToRelease)
        {
            if (objectToRelease is null) return;
            objectToRelease.SetActive(false);
            _availableObjects.Push(objectToRelease);
        }

        void ResetPool()
        {
            foreach (var gameObject in _allObjects)
                ReturnToPool(gameObject);
        }
    }
}
