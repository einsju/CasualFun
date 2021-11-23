using System;
using UnityEngine;

namespace CasualFun
{
    [Serializable]
    public class Pool
    {
        public int size = 10;
        public GameObject gameObject;
        public bool shouldDeactivateMembersBeforeUse = false;
    }
}
