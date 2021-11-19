using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CasualFun.Managers
{
    public class PoolManager
    {
        readonly GameObject _original;
        readonly Transform _parent;
        readonly int _size;
        readonly Stack<GameObject> _availableInstances;

        public PoolManager(GameObject original, Transform parent, int size = 10)
        {
            _original = original;
            _parent = parent;
            _size = size;
            _availableInstances = new Stack<GameObject>(_size);
            
            CreatePool();
        }

        void CreatePool()
        {
            for (var i = 0; i < _size; i++)
            {
                var objectToInstantiate = Object.Instantiate(_original, _parent, true);
                _availableInstances.Push(objectToInstantiate);
            }
        }

        public GameObject GrabObject() => ObjectToReturn(Vector3.zero, Quaternion.identity);

        public GameObject GrabObject(Vector3 position, Quaternion rotation) => ObjectToReturn(position, rotation);
        
        public void ReleaseObject(GameObject objectToRelease)
        {
            objectToRelease.SetActive(false);
            _availableInstances.Push(objectToRelease);
        }

        GameObject ObjectToReturn(Vector3 position, Quaternion rotation)
        {
            var objectFromStack = ObjectFromStack;
            
            objectFromStack.transform.position = position;
            objectFromStack.transform.rotation = rotation;
            objectFromStack.SetActive(true);

            return objectFromStack;
        }
        
        GameObject ObjectFromStack => _availableInstances.Any() ? _availableInstances.Pop() : Object.Instantiate(_original);
    }
}
