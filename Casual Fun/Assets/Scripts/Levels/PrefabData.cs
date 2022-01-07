using System;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game.Levels
{
    [Serializable]
    public class PrefabData
    {
        [Range(-360, 360)] [SerializeField] float degrees;
        [SerializeField] GameObject prefab;

        public float Degrees => degrees;
        public GameObject Prefab => prefab;
    }
}