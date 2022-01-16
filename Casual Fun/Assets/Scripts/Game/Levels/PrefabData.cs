using System;
using CasualFun.AtCirclesEdge.Utilities;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game.Levels
{
    [Serializable]
    public class PrefabData
    {
        [Range(-360, 360)] [SerializeField] float degrees;
        [SerializeField] GameObject prefab;
        [SerializeField] LevelPrefabPool pool;

        public float Degrees => degrees;
        public GameObject Prefab => prefab;
        public LevelPrefabPool Pool => pool;
    }
}