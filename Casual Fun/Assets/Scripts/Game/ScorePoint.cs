using CasualFun.AtCirclesEdge.Abstractions;
using UnityEngine;

namespace CasualFun.AtCirclesEdge.Game
{
    public class ScorePoint : MonoBehaviour, ICollectable
    {
        SpriteRenderer _renderer;

        void Awake() => _renderer = GetComponent<SpriteRenderer>();

        public void Collect()
        {
            EventManager.OnPlayerPickedUpCollectable(_renderer.transform.position);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
