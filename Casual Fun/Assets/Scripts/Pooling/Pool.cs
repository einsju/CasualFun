using System;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Pooling
{
    [Serializable]
    public class Pool
    {
        public int size = 10;
        public GameObject gameObject;
        public bool shouldDeactivateMembersBeforeUse;
    }
}
